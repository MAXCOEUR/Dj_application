using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dj_application.model
{
    public class SampleAggregator
    {
        private readonly int sampleRate;
        private readonly List<float> samples;

        public SampleAggregator(int sampleRate)
        {
            this.sampleRate = sampleRate;
            this.samples = new List<float>();
        }

        public void AddSamples(float[] buffer, int offset, int count)
        {
            for (int i = offset; i < offset + count; i++)
            {
                samples.Add(buffer[i]);
            }
        }

        public List<float> GetSnapshot()
        {
            lock (samples)
            {
                var snapshot = new List<float>(samples);
                samples.Clear();
                return snapshot;
            }
        }
    }

}
