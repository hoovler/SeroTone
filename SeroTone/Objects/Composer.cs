using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeroTone.Objects
{
    class Composer
    {
        public void WriteTones(string outFile)
        {
            // open the stream to an empty output file
            FileStream stream = new FileStream(outFile, FileMode.Create);
            BinaryWriter writer = new BinaryWriter(stream);

            // static variables
            int RIFF = 0x46464952;
            int WAVE = 0x45564157;
            int formatChunkSize = 16;
            int headerSize = 8;
            int format = 0x20746D66;
            short formatType = 1;
            short tracks = 1;
            int samplesPerSecond = 44100;
            short bitsPerSample = 16;
            int waveSize = 4;
            int data = 0x61746164;
            int samples = 88200 * 4;

            // set the base frequency (I prefer aNatural = 440.0)
            double aNatural = 220.0;
            double ampl = 10000;
            double perfect = 1.5;
            double concert = 1.498307077;

            // derived variables
            short frameSize = (short)(tracks * ((bitsPerSample + 7) / 8));
            int bytesPerSecond = samplesPerSecond * frameSize;
            int dataChunkSize = samples * frameSize;
            int fileSize = waveSize + headerSize + formatChunkSize + headerSize + dataChunkSize;

            // write to the stream...
            writer.Write(RIFF);
            writer.Write(fileSize);
            writer.Write(WAVE);
            writer.Write(format);
            writer.Write(formatChunkSize);
            writer.Write(formatType);
            writer.Write(tracks);
            writer.Write(samplesPerSecond);
            writer.Write(bytesPerSecond);
            writer.Write(frameSize);
            writer.Write(bitsPerSample);
            writer.Write(data);
            writer.Write(dataChunkSize);

            double freq = aNatural * perfect;

            for (int i = 0; i < samples / 4; i++)
            {
                double t = (double)i / (double)samplesPerSecond;
                short s = (short)(ampl * (Math.Sin(t * freq * 2.0 * Math.PI)));
                writer.Write(s);
            }
            freq = aNatural * concert;
            for (int i = 0; i < samples / 4; i++)
            {
                double t = (double)i / (double)samplesPerSecond;
                short s = (short)(ampl * (Math.Sin(t * freq * 2.0 * Math.PI)));
                writer.Write(s);
            }
            for (int i = 0; i < samples / 4; i++)
            {
                double t = (double)i / (double)samplesPerSecond;
                short s = (short)(ampl * (Math.Sin(t * freq * 2.0 * Math.PI) + Math.Sin(t * freq * perfect * 2.0 * Math.PI)));
                writer.Write(s);
            }
            for (int i = 0; i < samples / 4; i++)
            {
                double t = (double)i / (double)samplesPerSecond;
                short s = (short)(ampl * (Math.Sin(t * freq * 2.0 * Math.PI) + Math.Sin(t * freq * concert * 2.0 * Math.PI)));
                writer.Write(s);
            }
            writer.Close();
            stream.Close();
        }
    }
}
