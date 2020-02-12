using System;

namespace LinqToSQL
{
    /// <summary>
    /// Represents record in dynamics report.
    /// </summary>
    public class DynamicsRecord
    {
        /// <summary>
        /// Create an instanse of record(row in report).
        /// </summary>
        /// <param name="year">Average mark in Year.</param>
        /// <param name="maths">Average mark in Maths.</param>
        /// <param name="visualProgramming">Average mark in Visual Programming.</param>
        /// <param name="oOP">Average mark in OOP.</param>
        /// <param name="dBEngeneering">Average mark in DBEngeneering.</param>
        /// <param name="modeling">Average mark in 3DModeling.</param>
        /// <param name="cryptology">Average mark in Cryptology.</param>
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
        /// <summary>
        /// Property represent Year for report.
        /// </summary>
        public DateTime Year { get; }
        /// <summary>
        /// Property represent average mark in maths in Year.
        /// </summary>
        public double? Maths { get; }
        /// <summary>
        /// Property represent average mark in Visual Programming in Year.
        /// </summary>
        public double? VisualProgramming { get; }
        /// <summary>
        /// Property represent average mark in OOP in Year.
        /// </summary>
        public double? OOP { get; }
        /// <summary>
        /// Property represent average mark in DBEngeneering in Year.
        /// </summary>
        public double? DBEngeneering { get; }
        /// <summary>
        /// Property represent average mark in Modeling in Year.
        /// </summary>
        public double? Modeling { get; }
        /// <summary>
        /// Property represent average mark in Cryptology in Year.
        /// </summary>
        public double? Cryptology { get; }
    }
}
