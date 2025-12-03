using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.CCTV;

namespace BlaisePascal.SmartHouse.Domain.UnitTest
{
    public class CCTVTest
    {
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
        public void SetError_ShouldSetStatusError_AndStateIdle()
        {
            var cam = new CCTV.CCTV("Test Cam");
            cam.TurnOn();
            cam.StartRecording();

            cam.SetError();

            Assert.Equal(DeviceStatus.Error, cam.Status);
            Assert.Equal(CCTVStatus.Idle, cam.CCTVState);
        }
    }
}
    

