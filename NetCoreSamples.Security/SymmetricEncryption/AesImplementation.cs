using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace NetCoreSamples.Security.SymmetricEncryption
{
    // The Aes class, which was introduced in Framework 3.5
    public class AesImplementation
    {
        // Aes allow symmetric keys of length 16, 24, or 32 bytes
        private SymmetricAlgorithm algorithm;
        private ICryptoTransform encrypto;

        // 16-byte key
        // In this example, we made up a key of 16 randomly chosen bytes.If the wrong key
        // was used in decryption, CryptoStream would throw a CryptographicException.
        // Catching this exception is the only way to test whether a key is correct.
        byte[] key = { 145, 12, 32, 245, 98, 132, 98, 214, 6, 77, 131, 44, 221, 3, 9, 50 };
        // Initialization Vector
        //As well as a key, we made up an IV, or Initialization Vector.This 16-byte sequence
        //forms part of the cipher—much like the key—but is not considered secret.If transmitting
        //an encrypted message, you would send the IV in plain text (perhaps in a
        //message header) and then change it with every message.This would render each
        //encrypted message unrecognizable from any previous one—even if their unencrypted
        //versions were similar or identical.
        byte[] iv = { 15, 122, 132, 5, 93, 198, 44, 31, 9, 39, 241, 49, 250, 188, 80, 7 };


        //If you don’t need—or want—the protection of an IV, you can
        //defeat it by using the same 16-byte value for both the key and
        //the IV.Sending multiple messages with the same IV, though,
        //weakens the cipher and might even make it possible to crack.


        public AesImplementation()
        {
            algorithm = Aes.Create();
            encrypto = algorithm.CreateEncryptor(key, iv);

            // To generate a random key or IV, use RandomNumberGenerator in System.Cryptogra
            // phy.The numbers it produces are genuinely unpredictable, or cryptographically
            // strong(the System.Random class does not offer the same guarantee). 
            // Here’s an example:

            //byte[] key = new byte[16];
            //byte[] iv = new byte[16];
            //RandomNumberGenerator rand = RandomNumberGenerator.Create();
            //rand.GetBytes(key);
            //rand.GetBytes(iv);
        }

        // Will encrypt using default Unicode
        public string Encrypt(string text)
        {
            byte[] inputbuffer = Encoding.Unicode.GetBytes(text);
            byte[] outputBuffer = encrypto.TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);
            return Convert.ToBase64String(outputBuffer);
        }

        // Will decrypt to Unicode
        public string Decrypt(string encryptedText)
        {
            byte[] inputbuffer = Convert.FromBase64String(encryptedText);
            byte[] outputBuffer = encrypto.TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);
            return Encoding.Unicode.GetString(outputBuffer);
        }

        // In-memory encryption
        public byte[] Encrypt(byte[] data)
        {
            using (ICryptoTransform encryptor = algorithm.CreateEncryptor(key, iv))
                return Crypt(data, encryptor);
        }

        // In-memory decryption
        public byte[] Decrypt(byte[] data)
        {
            using (ICryptoTransform decryptor = algorithm.CreateDecryptor(key, iv))
                return Crypt(data, decryptor);
        }

        // In-memory crypt
        public byte[] Crypt(byte[] data, ICryptoTransform cryptor)
        {
            MemoryStream m = new MemoryStream();
            using (Stream c = new CryptoStream(m, cryptor, CryptoStreamMode.Write))
                c.Write(data, 0, data.Length);
            return m.ToArray();
        }
    }
}
