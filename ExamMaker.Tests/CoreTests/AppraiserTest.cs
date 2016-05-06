using ExamMaker.Core.Models;
using System;
using Xunit;

namespace ExamMaker.Tests.CoreTests {
    public class AppraiserTest {
        Appraiser measurer;
        public AppraiserTest() {
            measurer = new Appraiser("John Doe", "00438974208");
        }

        private void reset() {
            measurer.Name = "John Doe";
            measurer.Cpf = "00438974208";
        }

        [Fact]
        public void ShouldBeValidIfCpfLengthMinorOfEleven() {
            measurer.Cpf = "123";
            Assert.Throws<InvalidOperationException>(() => measurer.Validate());

            reset();

            Assert.True(measurer.Validate());
        }

        [Fact]
        public void ShouldBeValidOnlyIfAllPropertiesAreFulfilled() {
            measurer.Name = null;
            Assert.Throws<InvalidOperationException>(() => measurer.Validate());

            reset();
            measurer.Cpf = null;
            Assert.Throws<InvalidOperationException>(() => measurer.Validate());

            reset();
            Assert.True(measurer.Validate());
        }
    }
}
