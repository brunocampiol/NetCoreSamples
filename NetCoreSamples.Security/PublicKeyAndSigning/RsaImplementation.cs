using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace NetCoreSamples.Security.PublicKeyAndSigning
{
    public class RsaImplementation
    {
        RSACryptoServiceProvider rsa;

        public RsaImplementation()
        {
            rsa = new RSACryptoServiceProvider();
        }

        // In-memory encryption
        public byte[] Encrypt(byte[] data)
        {
            return rsa.Encrypt(data, true);
        }

        // In-memory decryption
        public byte[] Decrypt(byte[] data)
        {
            return rsa.Decrypt(data, true);
        }

        public string GetPublicKey()
        {
            return rsa.ToXmlString(false);
        }

        public string GetPrivateAndPublicKey()
        {
            return rsa.ToXmlString(false);
        }
    }
}
