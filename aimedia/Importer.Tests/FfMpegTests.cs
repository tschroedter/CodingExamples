using System;
using System.Linq;
using Importer.Interfaces;
using Xunit;

namespace Importer.Tests
{
    public sealed class FfMpegTests
    {
        private const float Tolerance = 0.001f;

        private const string OneSilencePointTwo =
            @"[silencedetect @ 0000000000342300] silence_start: 1.56472" + "\r\n" +
            @"[silencedetect @ 0000000000342300] silence_end: 1.76472 | silence_duration: 0.2" + "\r\n";

        private const string ThreeSilencesLessEqualGreaterPointTwo =
            @"[silencedetect @ 0000000000342300] silence_start: 1.56472" + "\r\n" +
            @"[silencedetect @ 0000000000342300] silence_end: 1.76472 | silence_duration: 0.19" + "\r\n" +
            @"[silencedetect @ 0000000000342300] silence_start: 14.7072" + "\r\n" +
            @"[silencedetect @ 0000000000342300] silence_end: 14.9537 | silence_duration: 0.2" + "\r\n" +
            @"[silencedetect @ 0000000000342300] silence_start: 19.4905" + "\r\n" +
            @"[silencedetect @ 0000000000342300] silence_end: 19.6905 | silence_duration: 0.21" + "\r\n";

        private const string FourSilencesPointTwo =
            @"[silencedetect @ 0000000000342300] silence_start: 1.56472" + "\r\n" +
            @"[silencedetect @ 0000000000342300] silence_end: 1.76472 | silence_duration: 0.2" + "\r\n" +
            @"[silencedetect @ 0000000000342300] silence_start: 14.7072" + "\r\n" +
            @"[silencedetect @ 0000000000342300] silence_end: 14.9537 | silence_duration: 0.24644" + "\r\n" +
            @"[silencedetect @ 0000000000342300] silence_start: 19.4905" + "\r\n" +
            @"[silencedetect @ 0000000000342300] silence_end: 19.6905 | silence_duration: 0.2" + "\r\n" +
            @"[silencedetect @ 0000000000342300] silence_start: 31.1934" + "\r\n" +
            @"[silencedetect @ 0000000000342300] silence_end: 31.4398 | silence_duration: 0.24644" + "\r\n";

        [Fact]
        public void Constructor_SetsText_ForOneSilence()
        {
            // Arrange
            // Act
            FfMpeg sut = CreateSut(OneSilencePointTwo);

            // Assert
            Assert.Equal(OneSilencePointTwo,
                         sut.Text);
        }

        [Fact]
        public void Constructor_SetsLines_ForOneSilence()
        {
            // Arrange
            // Act
            FfMpeg sut = CreateSut(OneSilencePointTwo);

            // Assert
            Assert.Equal(3,
                         sut.Lines.Count());
        }

        [Fact]
        public void Constructor_SetsText_FourSilencesPointTwo()
        {
            // Arrange
            // Act
            FfMpeg sut = CreateSut(FourSilencesPointTwo);

            // Assert
            Assert.Equal(FourSilencesPointTwo,
                         sut.Text);
        }

        [Fact]
        public void Constructor_SetsLines_FourSilencesPointTwo()
        {
            // Arrange
            // Act
            FfMpeg sut = CreateSut(FourSilencesPointTwo);

            // Assert
            Assert.Equal(9,
                         sut.Lines.Count());
        }

        [Fact]
        public void Constructor_SetsLines_ThreeSilencesLessEqualGreaterPointTwo()
        {
            // Arrange
            // Act
            FfMpeg sut = CreateSut(ThreeSilencesLessEqualGreaterPointTwo);

            // Assert
            Assert.Equal(7,
                         sut.Lines.Count());
        }

        [Fact]
        public void Find_FindsSilences_ForThreeSilencesLessEqualGreaterPointTwo()
        {
            // Arrange
            FfMpeg sut = CreateSut(ThreeSilencesLessEqualGreaterPointTwo);

            // Act
            sut.Find();

            // Assert
            Assert.Equal(2,
                         sut.Silences.Count());
        }

        [Fact]
        public void Find_FindsSilences_ForOneSilencePointTwo()
        {
            // Arrange
            FfMpeg sut = CreateSut(OneSilencePointTwo);

            // Act
            sut.Find();

            // Assert
            Assert.Equal(1,
                         sut.Silences.Count());
        }

        [Fact]
        public void Find_FindsSilences_ForFourSilencesPointTwo()
        {
            // Arrange
            FfMpeg sut = CreateSut(FourSilencesPointTwo);

            // Act
            sut.Find();

            // Assert
            Assert.Equal(4,
                         sut.Silences.Count());
        }

        [Fact]
        public void Find_FindsFirstSilence_ForFourSilencesPointTwo()
        {
            // Arrange
            FfMpeg sut = CreateSut(FourSilencesPointTwo);

            // Act
            sut.Find();
            ISilence actual = sut.Silences.ToArray() [ 0 ];

            // Assert
            Assert.True(Math.Abs(1.56472f - actual.Start) < Tolerance);
        }

        [Fact]
        public void Find_FindSecondSilence_ForFourSilencesPointTwo()
        {
            // Arrange
            FfMpeg sut = CreateSut(FourSilencesPointTwo);

            // Act
            sut.Find();
            ISilence actual = sut.Silences.ToArray() [ 1 ];

            // Assert
            Assert.True(Math.Abs(14.7072f - actual.Start) < Tolerance);
        }

        [Fact]
        public void Find_FindThirdSilence_ForFourSilencesPointTwo()
        {
            // Arrange
            FfMpeg sut = CreateSut(FourSilencesPointTwo);

            // Act
            sut.Find();
            ISilence actual = sut.Silences.ToArray() [ 2 ];

            // Assert
            Assert.True(Math.Abs(19.4905f - actual.Start) < Tolerance);
        }

        [Fact]
        public void Find_FindFourthSilence_ForFourSilencesPointTwo()
        {
            // Arrange
            FfMpeg sut = CreateSut(FourSilencesPointTwo);

            // Act
            sut.Find();
            ISilence actual = sut.Silences.ToArray() [ 3 ];

            // Assert
            Assert.True(Math.Abs(31.1934f - actual.Start) < Tolerance);
        }

        [Fact]
        public void Find_FindsSilenceWithStart_ForOneSilencePointTwo()
        {
            // Arrange
            FfMpeg sut = CreateSut(OneSilencePointTwo);
            sut.Find();

            // Act
            float actual = sut.Silences.First().Start;

            // Assert
            Assert.True(Math.Abs(1.56472f - actual) < Tolerance);
        }

        [Fact]
        public void Find_FindsSilenceWithEnd_ForOneSilencePointTwo()
        {
            // Arrange
            FfMpeg sut = CreateSut(OneSilencePointTwo);
            sut.Find();

            // Act
            float actual = sut.Silences.First().End;

            // Assert
            Assert.True(Math.Abs(1.76472f - actual) < Tolerance);
        }

        [Fact]
        public void Find_FindsSilenceWithDuration_ForOneSilencePointTwo()
        {
            // Arrange
            FfMpeg sut = CreateSut(OneSilencePointTwo);
            sut.Find();

            // Act
            float actual = sut.Silences.First().Duration;

            // Assert
            Assert.True(Math.Abs(0.2f - actual) < Tolerance);
        }

        [Fact]
        public void Find_FindsSilenceWithCutTime_ForOneSilencePointTwo()
        {
            // Arrange
            FfMpeg sut = CreateSut(OneSilencePointTwo);
            sut.Find();

            // Act
            float actual = sut.Silences.First().CutTime;

            // Assert
            Assert.True(Math.Abs(1.66472f - actual) < Tolerance);
        }

        private FfMpeg CreateSut(string text)
        {
            return new FfMpeg(text);
        }
    }
}