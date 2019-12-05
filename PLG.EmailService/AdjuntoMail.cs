using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLG.EmailService
{
    public class AdjuntoMail
    {
        private Stream _adjunto;

        public Stream Adjunto
        {
            get { return _adjunto; }
            set { _adjunto = value; }
        }
        private string _contentType;

        public string ContentType
        {
            get { return _contentType; }
            set {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("El campo contenType no puede ir vacio.");
                }
                else
                {
                    _contentType = value;
                }
            }
        }


        public AdjuntoMail(Stream stream,string contentType)
        {
            this.Adjunto = stream;
            this.ContentType = contentType;
        }
    }
}
