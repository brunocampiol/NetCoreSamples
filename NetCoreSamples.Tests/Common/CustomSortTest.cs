using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetCoreSamples.Common.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetCoreSamples.Tests.Common
{
    [TestClass]
    public class CustomSortTest
    {
        //public
        //Fully accessible.This is the implicit accessibility for members of an enum
        //or interface.

        //internal
        //Accessible only within the containing assembly or friend assemblies.This is
        //the default accessibility for non-nested types.

        //private
        //Accessible only within the containing type.This is the default accessibility
        //for members of a class or struct.

        //protected
        //Accessible only within the containing type or subclasses.

        //protected internal
        //The union of protected and internal accessibility.Eric Lippert explains it
        //as follows: Everything is as private as possible by default, and each modifier
        //makes the thing more accessible.So something that is protected internal
        //is made more accessible in two ways.

        private Circle GetRandomCircle()
        {
            Random random = new Random();

            int x = random.Next(0,100);
            int y = random.Next(0, 100);
            int radius = random.Next(0, 100);

            Point point = new Point()
            {
                X = x,
                Y = y
            };

            Circle circle = new Circle()
            {
                Position = point,
                Radius = radius
            };

            return circle;
        }


        [TestMethod]
        public void TestCustomSort()
        {
            // Assamble
            int numberOfCircles = 999999;
            List<Circle> circles = new List<Circle>();
            for (int i = 0; i < numberOfCircles; i++) circles.Add(GetRandomCircle());

            // Act
            circles.Sort();

            // Assert
            int previous = -1; // since we always generate > 0
            for (int i = 0; i < numberOfCircles; i++)
            {
                int currentRadius = circles[i].Radius;
                Assert.IsTrue(currentRadius >= previous);
                previous = currentRadius;
            }
        }

        [TestMethod]
        public void TestCustomSort_Linq()
        {
            // Assamble
            int numberOfCircles = 999999;
            List<Circle> circles = new List<Circle>();
            for (int i = 0; i < numberOfCircles; i++) circles.Add(GetRandomCircle());

            // Act
            List<Circle> sortedList = circles.OrderBy(x => x.Radius).ToList();

            // Assert
            int previous = -1; // since we always generate > 0
            for (int i = 0; i < numberOfCircles; i++)
            {
                int currentRadius = sortedList[i].Radius;
                Assert.IsTrue(currentRadius >= previous);
                previous = currentRadius;
            }
        }

    }
}
