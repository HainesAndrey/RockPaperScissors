using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Task3.RockPaperScissorsStuff
{
    public class Bot
    {
        private byte[] m_hmac;
        private byte[] m_key;
        private Random m_rnd;
        private IEnumerable<IFigure> m_figures;

        public IFigure SelectedFigure { get; private set; }
        public string Key => GetStringOfBytes(m_key);
        public string Hmac => GetStringOfBytes(m_hmac);

        public Bot() =>
            m_rnd = new Random();

        public void SetFigures(IEnumerable<IFigure> figures) =>
            m_figures = figures;

        public void MakeTurn()
        {
            SelectedFigure = GetRandomFigure();
            m_key = GetRandomKey();
            m_hmac = GetHmac(m_key, SelectedFigure.Name);
        }

        private IFigure GetRandomFigure() =>
            m_figures.Skip(m_rnd.Next(m_figures.Count())).First();

        private byte[] GetRandomKey()
        {
            var key = new byte[128 / 8];
            using (var gnrtr = RandomNumberGenerator.Create())
            {
                gnrtr.GetBytes(key);
            }
            return key;
        }

        private byte[] GetHmac(byte[] key, string figure)
        {
            using (var hmac = new HMACSHA256(key))
            {
                var fBytes = Encoding.ASCII.GetBytes(figure);
                return hmac.ComputeHash(fBytes);
            }
        }

        public static string GetStringOfBytes(byte[] arr) =>
            BitConverter.ToString(arr).Replace("-", "");
    }
}
