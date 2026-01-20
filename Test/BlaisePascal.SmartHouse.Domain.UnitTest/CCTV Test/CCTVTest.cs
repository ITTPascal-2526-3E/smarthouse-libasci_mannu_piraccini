using System;
using BlaisePascal.SmartHouse.Domain.CCTV;
using Xunit;

namespace BlaisePascal.SmartHouse.Domain.UnitTest
{
    public class CCTVTest
    {
        
        [Fact]
        public void Constructor_ShouldInitializeWithCorrectDefaults()
        {
            var cam = new CCTV.CCTV("Test Cam");

            Assert.NotEqual(Guid.Empty, cam.Id);
            Assert.Equal("Test Cam", cam.Name);
            Assert.Equal(DeviceStatus.Offline, cam.Status);
            Assert.Equal(CCTVStatus.Idle, cam.CCTVState);
        }

        [Fact]
        public void TurnOn_ShouldSetStatusOnline()
        {
            var cam = new CCTV.CCTV("Test Cam");

            cam.TurnOn();

            Assert.Equal(DeviceStatus.Online, cam.Status);
        }

        [Fact]
        public void TurnOff_ShouldSetStatusOffline_AndStateIdle()
        {
            var cam = new CCTV.CCTV("Test Cam");

            cam.TurnOn();
            cam.StartRecording();
            cam.TurnOff();

            Assert.Equal(DeviceStatus.Offline, cam.Status);
            Assert.Equal(CCTVStatus.Idle, cam.CCTVState);
        }

        [Fact]
        public void TurnOn_AfterError_ShouldSetOnline()
        {
            var cam = new CCTV.CCTV("Test Cam");

            cam.SetError();
            cam.TurnOn();

            Assert.Equal(DeviceStatus.Online, cam.Status);
            Assert.Equal(CCTVStatus.Idle, cam.CCTVState);
        }

        [Fact]
        public void StartRecording_ShouldSetRecording_WhenOnline()
        {
            var cam = new CCTV.CCTV("Test Cam");
            cam.TurnOn();

            cam.StartRecording();

            Assert.Equal(CCTVStatus.Recording, cam.CCTVState);
        }

        [Fact]
        public void StartRecording_ShouldDoNothing_WhenOffline()
        {
            var cam = new CCTV.CCTV("Test Cam");

            cam.StartRecording();

            Assert.Equal(CCTVStatus.Idle, cam.CCTVState);
        }

        [Fact]
        public void StopRecording_ShouldSetStateIdle()
        {
            var cam = new CCTV.CCTV("Test Cam");
            cam.TurnOn();
            cam.StartRecording();

            cam.StopRecording();

            Assert.Equal(CCTVStatus.Idle, cam.CCTVState);
        }

        [Fact]
        public void StartRecording_ShouldDoNothing_WhenInErrorState()
        {
            var cam = new CCTV.CCTV("Test Cam");
            cam.SetError();

            cam.StartRecording();

            Assert.Equal(CCTVStatus.Idle, cam.CCTVState);
            Assert.Equal(DeviceStatus.Error, cam.Status);
        }

        [Fact]
        public void SetError_ShouldSetStatusError_AndStateIdle()
        {
            var cam = new CCTV.CCTV("Test Cam");
            cam.TurnOn();
            cam.StartRecording();

            cam.SetError();

            Assert.Equal(DeviceStatus.Error, cam.Status);
            Assert.Equal(CCTVStatus.Idle, cam.CCTVState);
        }

        [Fact]
        public void CanSetNightVisionProperty()
        {
            var cam = new CCTV.CCTV("Test Cam");

            cam.NightVision = true;

            Assert.True(cam.NightVision);
        }
    }
}
