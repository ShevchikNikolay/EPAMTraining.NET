using System;

namespace LinqToSQL
{
    public class DynamicsRecord
    {
        public DynamicsRecord(
            DateTime year, double? maths, double? visualProgramming,
            double? oOP, double? dBEngeneering, double? modeling,
            double? cryptology)
        {
            Year = year;
            Maths = maths;
            VisualProgramming = visualProgramming;
            OOP = oOP;
            DBEngeneering = dBEngeneering;
            Modeling = modeling;
            Cryptology = cryptology;
        }
        public DateTime Year { get; }
        public double? Maths { get; }
        public double? VisualProgramming { get; }
        public double? OOP { get; }
        public double? DBEngeneering { get; }
        public double? Modeling { get; }
        public double? Cryptology { get; }
    }
}
