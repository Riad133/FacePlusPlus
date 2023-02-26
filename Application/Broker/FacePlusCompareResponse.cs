using System.Collections.Generic;

namespace FacePlusPlus.Application.Broker
{
   
    public  class FacePlusCompareResponse
    {
        public string RequestId { get; set; }
        public long TimeUsed { get; set; }
        public double Confidence { get; set; }
        public Dictionary<string, double> Thresholds { get; set; }
        public Faces[] Faces1 { get; set; }
        public Faces[] Faces2 { get; set; }
        public string ImageId1 { get; set; }
        public string ImageId2 { get; set; }
    }

    public  class Faces
    {
        public string FaceToken { get; set; }
        public FaceRectangle FaceRectangle { get; set; }
    }

    public  class FaceRectangle
    {
        public long Top { get; set; }
        public long Left { get; set; }
        public long Width { get; set; }
        public long Height { get; set; }
    }
}