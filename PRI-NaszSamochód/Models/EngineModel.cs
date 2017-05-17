using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PRI_NaszSamochód.Models
{
    public enum EngineType
    {
        Hybrid, Electric, Diesel, Gas, Petrol
    }

    public enum EngineConfiguration
    {
        I2, I3, I4, I5, I6, I7, I8, I9, I10, I12, I14,
        F2, F4, F6, F8, F10, F12, F16,
        V2, V3, V4, V5, V6, V8, V10, V12, V14, V16, V18, V20, V24,
        W8, W12, W16, W18
    }

    public enum EngineStrokes
    {
        Two, Four
    }

    public class EngineModel
    {
        [Key]
        [Required]
        public int Key { get; set; }

        public string Manufacturer { get; set; }
        public int EngineSpeed { get; set; }
        public string EngineSpeedUnit { get { return "RPM"; } }
        public int EnginePower { get; set; }
        public string EnginePowerUnit { get { return "BPH"; } }
        public EngineType EngineType { get; set; }
    }
}