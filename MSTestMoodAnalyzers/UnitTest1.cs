﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

using MoodAnalyzers;

namespace MoodAnalyzerMSTest
{
    [TestClass]
    public class UnitTest1
    {
        MoodAnalyzers.MoodAnalyzer moodAnalyzer = new MoodAnalyzer();


        [TestMethod]
        public void GivenSadMoodShouldReturnSAD()
        {
            //Arrange
            string expected = "SAD";

            //Act
            string actual = moodAnalyzer.AnalyzeMood("I am in Sad Mood");

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GivenAnyMoodShouldReturnHAPPY()
        {
            //Arrange
            string expected = "HAPPY";

            //Act
            string actual = moodAnalyzer.AnalyzeMood("I am in Any Mood");

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}