using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;
using AngleSharp.Media;
using YoutubeExplode.Videos;

namespace Dj_application.model
{
    public class MusiqueOnline
    {
        string path;
        IStreamInfo streamInfo;
        Video video;
        bool isInitialized;

        public MusiqueOnline(string path)
        {
            this.path = path;
            isInitialized = false;
            initMusique();
        }

        private async void initMusique()
        {
            var youtube = new YoutubeClient();

            StreamManifest streamManifest = await youtube.Videos.Streams.GetManifestAsync(path);
            streamInfo = streamManifest.GetAudioOnlyStreams().GetWithHighestBitrate();
            video = await youtube.Videos.GetAsync(path);
            isInitialized = true;
        }

        public async Task<string> GetTitreAsync()
        {
            await WaitForInitialization();
            return video.Title;
        }

        public async Task<double> GetDureeAsync()
        {
            await WaitForInitialization();
            TimeSpan? duration = video.Duration;
            if (duration == null)
            {
                return 0;
            }
            return duration.Value.TotalSeconds;
        }

        private async Task WaitForInitialization()
        {
            while (!isInitialized)
            {
                await Task.Delay(100);
            }
        }

        public string GetUrlStream()
        {
            return streamInfo.Url;
        }

        public string GetUrl()
        {
            return path;
        }
    }


}
