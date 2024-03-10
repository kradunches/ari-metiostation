using System.Collections;

namespace ServerMVC.Infrastructure.Statistics
{
    public class OneFactorData
    {
        double[] Observations;
        public int Length;
        public OneFactorData(double[] observations)
        {
            Observations = observations;
            Length = observations.Length;
        }
        public double this[int index]
        {
            get => Observations[index];
            set => Observations[index] = value;
        }
        public IEnumerator GetEnumerator() => Observations.GetEnumerator();
    }

    public struct FTableKey
    {
        int col;
        int row;
        public FTableKey(int col, int row)
        {
            this.col = col;
            this.row = row;
        }
    }
    public class Anova
    {
        public double SS { get; }
        public double SSa { get; }
        public double SSe { get; }
        /// <summary>
        /// Общее число наблюдений
        /// </summary>
        public int n { get; }
        public double avgX { get; }
        public int dfA { get; }
        public int df { get; }
        public double MSa { get; }
        public double MSe { get; }
        public double F { get; }
        public double Fcrit { get; }
        public double p { get; }
        public double Frnk { get; set; }
        public double Prnk { get; set; }
        public Anova(OneFactorData[] groups)
        {
            dfA = groups.Length - 1;
            foreach (OneFactorData group in groups)
            {
                n += group.Length;
                foreach (double obs in group)
                {
                    avgX += obs;
                }
            }
            df = n - groups.Length;
            avgX /= n;

            foreach (OneFactorData group in groups)
            {
                int ni = group.Length;
                double avgXi = 0;
                foreach (double obs in group)
                {
                    avgXi += obs;
                    SS += (obs - avgX) * (obs - avgX);
                }
                avgXi /= ni;
                SSa += (avgXi - avgX) * (avgXi - avgX) * ni;
                foreach (double obs in group)
                    SSe += (obs - avgXi) * (obs - avgXi);
            }
            MSa = SSa / dfA;
            MSe = SSe / df;
            F = MSa / MSe;

            Dictionary<FTableKey, double> Ftable = new Dictionary<FTableKey, double>()
        { 
        #region
        {new FTableKey(1, 1), 161.40},
        {new FTableKey(1, 2), 199.50},
        {new FTableKey(1, 3), 215.70},
        {new FTableKey(1, 4), 224.60},
        {new FTableKey(1, 5), 230.20},
        {new FTableKey(1, 6), 234.00},
        {new FTableKey(1, 8), 238.90},
        {new FTableKey(1, 12), 243.90},
        {new FTableKey(1, 16), 246.50},
        {new FTableKey(1, 24), 249.00},
        {new FTableKey(1, 50), 251.80},
        {new FTableKey(1, 51), 254.30},

        {new FTableKey(2, 1), 18.51},
        {new FTableKey(2, 2), 19.00},
        {new FTableKey(2, 3), 19.16},
        {new FTableKey(2, 4), 19.25},
        {new FTableKey(2, 5), 19.30},
        {new FTableKey(2, 6), 19.33},
        {new FTableKey(2, 8), 19.37},
        {new FTableKey(2, 12), 19.41},
        {new FTableKey(2, 16), 19.43},
        {new FTableKey(2, 24), 19.45},
        {new FTableKey(2, 50), 19.47},
        {new FTableKey(2, 51), 19.50},

        {new FTableKey(3, 1), 10.13},
        {new FTableKey(3, 2), 9.55},
        {new FTableKey(3, 3), 9.28},
        {new FTableKey(3, 4), 9.12},
        {new FTableKey(3, 5), 9.01},
        {new FTableKey(3, 6), 8.94},
        {new FTableKey(3, 8), 8.84},
        {new FTableKey(3, 12), 8.74},
        {new FTableKey(3, 16), 8.69},
        {new FTableKey(3, 24), 8.64},
        {new FTableKey(3, 50), 8.58},
        {new FTableKey(3, 51), 8.53},

        {new FTableKey(4, 1), 7.71},
        {new FTableKey(4, 2), 6.94},
        {new FTableKey(4, 3), 6.59},
        {new FTableKey(4, 4), 6.39},
        {new FTableKey(4, 5), 6.26},
        {new FTableKey(4, 6), 6.16},
        {new FTableKey(4, 8), 6.04},
        {new FTableKey(4, 12), 5.91},
        {new FTableKey(4, 16), 5.84},
        {new FTableKey(4, 24), 5.77},
        {new FTableKey(4, 50), 5.70},
        {new FTableKey(4, 51), 5.63},

        {new FTableKey(5, 1), 6.61},
        {new FTableKey(5, 2), 5.79},
        {new FTableKey(5, 3), 5.41},
        {new FTableKey(5, 4), 5.19},
        {new FTableKey(5, 5), 5.05},
        {new FTableKey(5, 6), 4.95},
        {new FTableKey(5, 8), 4.82},
        {new FTableKey(5, 12), 4.68},
        {new FTableKey(5, 16), 4.60},
        {new FTableKey(5, 24), 4.53},
        {new FTableKey(5, 50), 4.44},
        {new FTableKey(5, 51), 4.36},

        {new FTableKey(6, 1), 5.99},
        {new FTableKey(6, 2), 5.14},
        {new FTableKey(6, 3), 4.76},
        {new FTableKey(6, 4), 4.53},
        {new FTableKey(6, 5), 4.39},
        {new FTableKey(6, 6), 4.28},
        {new FTableKey(6, 8), 4.15},
        {new FTableKey(6, 12), 4.00},
        {new FTableKey(6, 16), 3.92},
        {new FTableKey(6, 24), 3.84},
        {new FTableKey(6, 50), 3.75},
        {new FTableKey(6, 51), 3.67},

        {new FTableKey(7, 1), 5.59},
        {new FTableKey(7, 2), 4.74},
        {new FTableKey(7, 3), 4.35},
        {new FTableKey(7, 4), 4.12},
        {new FTableKey(7, 5), 3.97},
        {new FTableKey(7, 6), 3.87},
        {new FTableKey(7, 8), 3.73},
        {new FTableKey(7, 12), 3.57},
        {new FTableKey(7, 16), 3.49},
        {new FTableKey(7, 24), 3.41},
        {new FTableKey(7, 50), 3.32},
        {new FTableKey(7, 51), 3.23},

        {new FTableKey(8, 1), 5.32},
        {new FTableKey(8, 2), 4.48},
        {new FTableKey(8, 3), 4.07},
        {new FTableKey(8, 4), 3.84},
        {new FTableKey(8, 5), 3.69},
        {new FTableKey(8, 6), 3.58},
        {new FTableKey(8, 8), 3.44},
        {new FTableKey(8, 12), 3.28},
        {new FTableKey(8, 16), 3.20},
        {new FTableKey(8, 24), 3.12},
        {new FTableKey(8, 50), 3.02},
        {new FTableKey(8, 51), 2.93},

        {new FTableKey(9, 1), 5.12},
        {new FTableKey(9, 2), 4.26},
        {new FTableKey(9, 3), 3.86},
        {new FTableKey(9, 4), 3.63},
        {new FTableKey(9, 5), 3.48},
        {new FTableKey(9, 6), 3.37},
        {new FTableKey(9, 8), 3.23},
        {new FTableKey(9, 12), 3.07},
        {new FTableKey(9, 16), 2.98},
        {new FTableKey(9, 24), 2.90},
        {new FTableKey(9, 50), 2.80},
        {new FTableKey(9, 51), 2.71},

        {new FTableKey(10, 1), 4.96},
        {new FTableKey(10, 2), 4.10},
        {new FTableKey(10, 3), 3.71},
        {new FTableKey(10, 4), 3.48},
        {new FTableKey(10, 5), 3.33},
        {new FTableKey(10, 6), 3.22},
        {new FTableKey(10, 8), 3.07},
        {new FTableKey(10, 12), 2.91},
        {new FTableKey(10, 16), 2.82},
        {new FTableKey(10, 24), 2.74},
        {new FTableKey(10, 50), 2.64},
        {new FTableKey(10, 51), 2.54},

        {new FTableKey(11, 1), 4.84},
        {new FTableKey(11, 2), 3.98},
        {new FTableKey(11, 3), 3.59},
        {new FTableKey(11, 4), 3.36},
        {new FTableKey(11, 5), 3.20},
        {new FTableKey(11, 6), 3.09},
        {new FTableKey(11, 8), 2.95},
        {new FTableKey(11, 12), 2.79},
        {new FTableKey(11, 16), 2.70},
        {new FTableKey(11, 24), 2.61},
        {new FTableKey(11, 50), 2.50},
        {new FTableKey(11, 51), 2.40},

        {new FTableKey(12, 1), 4.75},
        {new FTableKey(12, 2), 3.88},
        {new FTableKey(12, 3), 3.49},
        {new FTableKey(12, 4), 3.26},
        {new FTableKey(12, 5), 3.11},
        {new FTableKey(12, 6), 3.00},
        {new FTableKey(12, 8), 2.85},
        {new FTableKey(12, 12), 2.69},
        {new FTableKey(12, 16), 2.60},
        {new FTableKey(12, 24), 2.50},
        {new FTableKey(12, 50), 2.40},
        {new FTableKey(12, 51), 2.30},

        {new FTableKey(13, 1), 4.67},
        {new FTableKey(13, 2), 3.80},
        {new FTableKey(13, 3), 3.41},
        {new FTableKey(13, 4), 3.18},
        {new FTableKey(13, 5), 3.02},
        {new FTableKey(13, 6), 2.92},
        {new FTableKey(13, 8), 2.77},
        {new FTableKey(13, 12), 2.60},
        {new FTableKey(13, 16), 2.51},
        {new FTableKey(13, 24), 2.42},
        {new FTableKey(13, 50), 2.32},
        {new FTableKey(13, 51), 2.21},

        {new FTableKey(14, 1), 4.60},
        {new FTableKey(14, 2), 3.74},
        {new FTableKey(14, 3), 3.34},
        {new FTableKey(14, 4), 3.11},
        {new FTableKey(14, 5), 2.96},
        {new FTableKey(14, 6), 2.85},
        {new FTableKey(14, 8), 2.70},
        {new FTableKey(14, 12), 2.53},
        {new FTableKey(14, 16), 2.44},
        {new FTableKey(14, 24), 2.35},
        {new FTableKey(14, 50), 2.24},
        {new FTableKey(14, 51), 2.13},

        {new FTableKey(15, 1), 4.54},
        {new FTableKey(15, 2), 3.68},
        {new FTableKey(15, 3), 3.29},
        {new FTableKey(15, 4), 3.06},
        {new FTableKey(15, 5), 2.90},
        {new FTableKey(15, 6), 2.79},
        {new FTableKey(15, 8), 2.64},
        {new FTableKey(15, 12), 2.48},
        {new FTableKey(15, 16), 2.39},
        {new FTableKey(15, 24), 2.29},
        {new FTableKey(15, 50), 2.18},
        {new FTableKey(15, 51), 2.07},

        {new FTableKey(16, 1), 4.49},
        {new FTableKey(16, 2), 3.63},
        {new FTableKey(16, 3), 3.24},
        {new FTableKey(16, 4), 3.01},
        {new FTableKey(16, 5), 2.85},
        {new FTableKey(16, 6), 2.74},
        {new FTableKey(16, 8), 2.59},
        {new FTableKey(16, 12), 2.42},
        {new FTableKey(16, 16), 2.33},
        {new FTableKey(16, 24), 2.24},
        {new FTableKey(16, 50), 2.13},
        {new FTableKey(16, 51), 2.01},

        {new FTableKey(17, 1), 4.45},
        {new FTableKey(17, 2), 3.59},
        {new FTableKey(17, 3), 3.20},
        {new FTableKey(17, 4), 2.96},
        {new FTableKey(17, 5), 2.81},
        {new FTableKey(17, 6), 2.70},
        {new FTableKey(17, 8), 2.55},
        {new FTableKey(17, 12), 2.38},
        {new FTableKey(17, 16), 2.29},
        {new FTableKey(17, 24), 2.19},
        {new FTableKey(17, 50), 2.08},
        {new FTableKey(17, 51), 1.96},

        {new FTableKey(18, 1), 4.41},
        {new FTableKey(18, 2), 3.55},
        {new FTableKey(18, 3), 3.16},
        {new FTableKey(18, 4), 2.93},
        {new FTableKey(18, 5), 2.77},
        {new FTableKey(18, 6), 2.66},
        {new FTableKey(18, 8), 2.51},
        {new FTableKey(18, 12), 2.34},
        {new FTableKey(18, 16), 2.25},
        {new FTableKey(18, 24), 2.15},
        {new FTableKey(18, 50), 2.04},
        {new FTableKey(18, 51), 1.92},

        {new FTableKey(19, 1), 4.38},
        {new FTableKey(19, 2), 3.52},
        {new FTableKey(19, 3), 3.13},
        {new FTableKey(19, 4), 2.90},
        {new FTableKey(19, 5), 2.74},
        {new FTableKey(19, 6), 2.63},
        {new FTableKey(19, 8), 2.48},
        {new FTableKey(19, 12), 2.31},
        {new FTableKey(19, 16), 2.21},
        {new FTableKey(19, 24), 2.11},
        {new FTableKey(19, 50), 2.00},
        {new FTableKey(19, 51), 1.88},

        {new FTableKey(20, 1), 4.35},
        {new FTableKey(20, 2), 3.49},
        {new FTableKey(20, 3), 3.10},
        {new FTableKey(20, 4), 2.87},
        {new FTableKey(20, 5), 3.71},
        {new FTableKey(20, 6), 2.60},
        {new FTableKey(20, 8), 2.45},
        {new FTableKey(20, 12), 2.28},
        {new FTableKey(20, 16), 2.18},
        {new FTableKey(20, 24), 2.08},
        {new FTableKey(20, 50), 1.96},
        {new FTableKey(20, 51), 1.84},

        {new FTableKey(21, 1), 4.32},
        {new FTableKey(21, 2), 3.47},
        {new FTableKey(21, 3), 3.07},
        {new FTableKey(21, 4), 2.84},
        {new FTableKey(21, 5), 2.68},
        {new FTableKey(21, 6), 2.57},
        {new FTableKey(21, 8), 2.42},
        {new FTableKey(21, 12), 2.25},
        {new FTableKey(21, 16), 2.15},
        {new FTableKey(21, 24), 2.05},
        {new FTableKey(21, 50), 1.93},
        {new FTableKey(21, 51), 1.81},

        {new FTableKey(22, 1), 4.30},
        {new FTableKey(22, 2), 3.44},
        {new FTableKey(22, 3), 3.05},
        {new FTableKey(22, 4), 2.82},
        {new FTableKey(22, 5), 2.66},
        {new FTableKey(22, 6), 2.55},
        {new FTableKey(22, 8), 2.40},
        {new FTableKey(22, 12), 2.23},
        {new FTableKey(22, 16), 2.13},
        {new FTableKey(22, 24), 2.03},
        {new FTableKey(22, 50), 1.91},
        {new FTableKey(22, 51), 1.78},

        {new FTableKey(23, 1), 4.28},
        {new FTableKey(23, 2), 3.42},
        {new FTableKey(23, 3), 3.03},
        {new FTableKey(23, 4), 2.80},
        {new FTableKey(23, 5), 2.64},
        {new FTableKey(23, 6), 2.53},
        {new FTableKey(23, 8), 2.38},
        {new FTableKey(23, 12), 2.20},
        {new FTableKey(23, 16), 2.11},
        {new FTableKey(23, 24), 2.00},
        {new FTableKey(23, 50), 1.88},
        {new FTableKey(23, 51), 1.76},

        {new FTableKey(24, 1), 4.26},
        {new FTableKey(24, 2), 3.40},
        {new FTableKey(24, 3), 3.01},
        {new FTableKey(24, 4), 2.78},
        {new FTableKey(24, 5), 2.62},
        {new FTableKey(24, 6), 2.51},
        {new FTableKey(24, 8), 2.36},
        {new FTableKey(24, 12), 2.18},
        {new FTableKey(24, 16), 2.09},
        {new FTableKey(24, 24), 1.98},
        {new FTableKey(24, 50), 1.86},
        {new FTableKey(24, 51), 1.73},

        {new FTableKey(25, 1), 4.24},
        {new FTableKey(25, 2), 3.38},
        {new FTableKey(25, 3), 2.99},
        {new FTableKey(25, 4), 2.76},
        {new FTableKey(25, 5), 2.60},
        {new FTableKey(25, 6), 2.49},
        {new FTableKey(25, 8), 2.34},
        {new FTableKey(25, 12), 2.16},
        {new FTableKey(25, 16), 2.07},
        {new FTableKey(25, 24), 1.96},
        {new FTableKey(25, 50), 1.84},
        {new FTableKey(25, 51), 1.71},

        {new FTableKey(26, 1), 4.22},
        {new FTableKey(26, 2), 3.37},
        {new FTableKey(26, 3), 2.98},
        {new FTableKey(26, 4), 2.74},
        {new FTableKey(26, 5), 2.59},
        {new FTableKey(26, 6), 2.47},
        {new FTableKey(26, 8), 2.32},
        {new FTableKey(26, 12), 2.15},
        {new FTableKey(26, 16), 2.05},
        {new FTableKey(26, 24), 1.95},
        {new FTableKey(26, 50), 1.82},
        {new FTableKey(26, 51), 1.69},

        {new FTableKey(27, 1), 4.21},
        {new FTableKey(27, 2), 3.35},
        {new FTableKey(27, 3), 2.96},
        {new FTableKey(27, 4), 2.73},
        {new FTableKey(27, 5), 2.57},
        {new FTableKey(27, 6), 2.46},
        {new FTableKey(27, 8), 2.30},
        {new FTableKey(27, 12), 2.13},
        {new FTableKey(27, 16), 2.03},
        {new FTableKey(27, 24), 1.93},
        {new FTableKey(27, 50), 1.80},
        {new FTableKey(27, 51), 1.67},

        {new FTableKey(28, 1), 4.20},
        {new FTableKey(28, 2), 3.34},
        {new FTableKey(28, 3), 2.95},
        {new FTableKey(28, 4), 2.71},
        {new FTableKey(28, 5), 2.56},
        {new FTableKey(28, 6), 2.44},
        {new FTableKey(28, 8), 2.29},
        {new FTableKey(28, 12), 2.12},
        {new FTableKey(28, 16), 2.02},
        {new FTableKey(28, 24), 1.91},
        {new FTableKey(28, 50), 1.78},
        {new FTableKey(28, 51), 1.65},

        {new FTableKey(29, 1), 4.18},
        {new FTableKey(29, 2), 3.33},
        {new FTableKey(29, 3), 2.93},
        {new FTableKey(29, 4), 2.70},
        {new FTableKey(29, 5), 2.54},
        {new FTableKey(29, 6), 2.43},
        {new FTableKey(29, 8), 2.28},
        {new FTableKey(29, 12), 2.10},
        {new FTableKey(29, 16), 2.00},
        {new FTableKey(29, 24), 1.90},
        {new FTableKey(29, 50), 1.77},
        {new FTableKey(29, 51), 1.64},

        {new FTableKey(30, 1), 4.17},
        {new FTableKey(30, 2), 3.32},
        {new FTableKey(30, 3), 2.92},
        {new FTableKey(30, 4), 2.69},
        {new FTableKey(30, 5), 2.53},
        {new FTableKey(30, 6), 2.42},
        {new FTableKey(30, 8), 2.27},
        {new FTableKey(30, 12), 2.09},
        {new FTableKey(30, 16), 1.99},
        {new FTableKey(30, 24), 1.89},
        {new FTableKey(30, 50), 1.76},
        {new FTableKey(30, 51), 1.62},

        {new FTableKey(35, 1), 4.12},
        {new FTableKey(35, 2), 3.26},
        {new FTableKey(35, 3), 2.87},
        {new FTableKey(35, 4), 2.64},
        {new FTableKey(35, 5), 2.48},
        {new FTableKey(35, 6), 2.37},
        {new FTableKey(35, 8), 2.22},
        {new FTableKey(35, 12), 2.04},
        {new FTableKey(35, 16), 1.94},
        {new FTableKey(35, 24), 1.83},
        {new FTableKey(35, 50), 1.70},
        {new FTableKey(35, 51), 1.57},

        {new FTableKey(40, 1), 4.08},
        {new FTableKey(40, 2), 5.23},
        {new FTableKey(40, 3), 2.84},
        {new FTableKey(40, 4), 2.61},
        {new FTableKey(40, 5), 2.45},
        {new FTableKey(40, 6), 2.34},
        {new FTableKey(40, 8), 2.18},
        {new FTableKey(40, 12), 2.00},
        {new FTableKey(40, 16), 1.90},
        {new FTableKey(40, 24), 1.79},
        {new FTableKey(40, 50), 1.66},
        {new FTableKey(40, 51), 1.51},

        {new FTableKey(45, 1), 4.06},
        {new FTableKey(45, 2), 3.21},
        {new FTableKey(45, 3), 2.81},
        {new FTableKey(45, 4), 2.58},
        {new FTableKey(45, 5), 2.42},
        {new FTableKey(45, 6), 2.31},
        {new FTableKey(45, 8), 2.15},
        {new FTableKey(45, 12), 1.97},
        {new FTableKey(45, 16), 1.87},
        {new FTableKey(45, 24), 1.76},
        {new FTableKey(45, 50), 1.63},
        {new FTableKey(45, 51), 1.48},

        {new FTableKey(50, 1), 4.03},
        {new FTableKey(50, 2), 3.18},
        {new FTableKey(50, 3), 2.79},
        {new FTableKey(50, 4), 2.56},
        {new FTableKey(50, 5), 2.40},
        {new FTableKey(50, 6), 2.29},
        {new FTableKey(50, 8), 2.13},
        {new FTableKey(50, 12), 1.95},
        {new FTableKey(50, 16), 1.85},
        {new FTableKey(50, 24), 1.74},
        {new FTableKey(50, 50), 1.60},
        {new FTableKey(50, 51), 1.44},

        {new FTableKey(60, 1), 4.00},
        {new FTableKey(60, 2), 3.15},
        {new FTableKey(60, 3), 2.76},
        {new FTableKey(60, 4), 2.52},
        {new FTableKey(60, 5), 2.37},
        {new FTableKey(60, 6), 2.25},
        {new FTableKey(60, 8), 2.10},
        {new FTableKey(60, 12), 1.92},
        {new FTableKey(60, 16), 1.81},
        {new FTableKey(60, 24), 1.70},
        {new FTableKey(60, 50), 1.56},
        {new FTableKey(60, 51), 1.39},

        {new FTableKey(70, 1), 3.98},
        {new FTableKey(70, 2), 3.13},
        {new FTableKey(70, 3), 2.74},
        {new FTableKey(70, 4), 2.50},
        {new FTableKey(70, 5), 2.35},
        {new FTableKey(70, 6), 2.23},
        {new FTableKey(70, 8), 2.07},
        {new FTableKey(70, 12), 1.89},
        {new FTableKey(70, 16), 1.79},
        {new FTableKey(70, 24), 1.67},
        {new FTableKey(70, 50), 1.53},
        {new FTableKey(70, 51), 1.35},

        {new FTableKey(80, 1), 3.96},
        {new FTableKey(80, 2), 3.11},
        {new FTableKey(80, 3), 2.72},
        {new FTableKey(80, 4), 2.49},
        {new FTableKey(80, 5), 2.33},
        {new FTableKey(80, 6), 2.21},
        {new FTableKey(80, 8), 2.06},
        {new FTableKey(80, 12), 1.88},
        {new FTableKey(80, 16), 1.77},
        {new FTableKey(80, 24), 1.65},
        {new FTableKey(80, 50), 1.51},
        {new FTableKey(80, 51), 1.32},

        {new FTableKey(90, 1), 3.95},
        {new FTableKey(90, 2), 3.10},
        {new FTableKey(90, 3), 2.71},
        {new FTableKey(90, 4), 2.47},
        {new FTableKey(90, 5), 2.32},
        {new FTableKey(90, 6), 2.20},
        {new FTableKey(90, 8), 2.04},
        {new FTableKey(90, 12), 1.86},
        {new FTableKey(90, 16), 1.76},
        {new FTableKey(90, 24), 1.64},
        {new FTableKey(90, 50), 1.49},
        {new FTableKey(90, 51), 1.30},

        {new FTableKey(100, 1), 3.94},
        {new FTableKey(100, 2), 3.09},
        {new FTableKey(100, 3), 2.70},
        {new FTableKey(100, 4), 2.46},
        {new FTableKey(100, 5), 2.30},
        {new FTableKey(100, 6), 2.19},
        {new FTableKey(100, 8), 2.03},
        {new FTableKey(100, 12), 1.85},
        {new FTableKey(100, 16), 1.75},
        {new FTableKey(100, 24), 1.63},
        {new FTableKey(100, 50), 1.48},
        {new FTableKey(100, 51), 1.28},

        {new FTableKey(125, 1), 3.92},
        {new FTableKey(125, 2), 3.07},
        {new FTableKey(125, 3), 2.68},
        {new FTableKey(125, 4), 2.44},
        {new FTableKey(125, 5), 2.29},
        {new FTableKey(125, 6), 2.17},
        {new FTableKey(125, 8), 2.01},
        {new FTableKey(125, 12), 1.83},
        {new FTableKey(125, 16), 1.72},
        {new FTableKey(125, 24), 1.60},
        {new FTableKey(125, 50), 1.45},
        {new FTableKey(125, 51), 1.25},

        {new FTableKey(150, 1), 3.90},
        {new FTableKey(150, 2), 3.06},
        {new FTableKey(150, 3), 2.66},
        {new FTableKey(150, 4), 2.43},
        {new FTableKey(150, 5), 2.27},
        {new FTableKey(150, 6), 2.16},
        {new FTableKey(150, 8), 2.00},
        {new FTableKey(150, 12), 1.82},
        {new FTableKey(150, 16), 1.71},
        {new FTableKey(150, 24), 1.59},
        {new FTableKey(150, 50), 1.44},
        {new FTableKey(150, 51), 1.22},

        {new FTableKey(200, 1), 3.89},
        {new FTableKey(200, 2), 3.04},
        {new FTableKey(200, 3), 2.65},
        {new FTableKey(200, 4), 2.42},
        {new FTableKey(200, 5), 2.26},
        {new FTableKey(200, 6), 2.14},
        {new FTableKey(200, 8), 1.98},
        {new FTableKey(200, 12), 1.80},
        {new FTableKey(200, 16), 1.69},
        {new FTableKey(200, 24), 1.57},
        {new FTableKey(200, 50), 1.42},
        {new FTableKey(200, 51), 1.19},

        {new FTableKey(300, 1), 3.87},
        {new FTableKey(300, 2), 3.03},
        {new FTableKey(300, 3), 2.64},
        {new FTableKey(300, 4), 2.41},
        {new FTableKey(300, 5), 2.25},
        {new FTableKey(300, 6), 2.13},
        {new FTableKey(300, 8), 1.97},
        {new FTableKey(300, 12), 1.79},
        {new FTableKey(300, 16), 1.68},
        {new FTableKey(300, 24), 1.55},
        {new FTableKey(300, 50), 1.39},
        {new FTableKey(300, 51), 1.15},

        {new FTableKey(400, 1), 3.86},
        {new FTableKey(400, 2), 3.02},
        {new FTableKey(400, 3), 2.63},
        {new FTableKey(400, 4), 2.40},
        {new FTableKey(400, 5), 2.24},
        {new FTableKey(400, 6), 2.12},
        {new FTableKey(400, 8), 1.96},
        {new FTableKey(400, 12), 1.78},
        {new FTableKey(400, 16), 1.67},
        {new FTableKey(400, 24), 1.54},
        {new FTableKey(400, 50), 1.38},
        {new FTableKey(400, 51), 1.13},

        {new FTableKey(500, 1), 3.86},
        {new FTableKey(500, 2), 3.01},
        {new FTableKey(500, 3), 2.62},
        {new FTableKey(500, 4), 2.39},
        {new FTableKey(500, 5), 2.23},
        {new FTableKey(500, 6), 2.11},
        {new FTableKey(500, 8), 1.96},
        {new FTableKey(500, 12), 1.77},
        {new FTableKey(500, 16), 1.66},
        {new FTableKey(500, 24), 1.54},
        {new FTableKey(500, 50), 1.38},
        {new FTableKey(500, 51), 1.11},

        {new FTableKey(1000, 1), 3.85},
        {new FTableKey(1000, 2), 3.00},
        {new FTableKey(1000, 3), 2.61},
        {new FTableKey(1000, 4), 2.38},
        {new FTableKey(1000, 5), 2.22},
        {new FTableKey(1000, 6), 2.10},
        {new FTableKey(1000, 8), 1.95},
        {new FTableKey(1000, 12), 1.76},
        {new FTableKey(1000, 16), 1.65},
        {new FTableKey(1000, 24), 1.53},
        {new FTableKey(1000, 50), 1.36},
        {new FTableKey(1000, 51), 1.08},

        {new FTableKey(1001, 1), 3.84},
        {new FTableKey(1001, 2), 2.99},
        {new FTableKey(1001, 3), 2.60},
        {new FTableKey(1001, 4), 2.37},
        {new FTableKey(1001, 5), 2.21},
        {new FTableKey(1001, 6), 2.09},
        {new FTableKey(1001, 8), 1.94},
        {new FTableKey(1001, 12), 1.75},
        {new FTableKey(1001, 16), 1.64},
        {new FTableKey(1001, 24), 1.52},
        {new FTableKey(1001, 50), 1.35},
        {new FTableKey(1001, 51), 1.00}
            #endregion
    };
            int[] tableDfAxArr = new int[] { 1, 2, 3, 4, 5, 6, 8, 12, 16, 24, 50, 51 };

            int tmpA = dfA;
            int resAx = 0;
            for (int i = 0; i < tableDfAxArr.Length; i++)
            {
                if (tmpA >= Math.Abs(dfA - tableDfAxArr[i]))
                {
                    tmpA = Math.Abs(dfA - tableDfAxArr[i]);
                    resAx = tableDfAxArr[i];
                }
            }

            int[] tableDfyArr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 35, 40, 45, 50, 60, 70, 80, 90, 100, 125, 150, 200, 300, 400, 500, 1000, 1001 };
            int tmp = df;
            int resy = 0;
            for (int i = 0; i < tableDfyArr.Length; i++)
            {
                if (tmp >= Math.Abs(df - tableDfyArr[i]))
                {
                    tmp = Math.Abs(df - tableDfyArr[i]);
                    resy = tableDfyArr[i];
                }
            }
            FTableKey neededFtableKey = new FTableKey(resy, resAx);
            if (resy == 0 || resAx == 0)
                return;
            Fcrit = Ftable[neededFtableKey];
            FdistributionCalculator fdc = new FdistributionCalculator();
            p = fdc.fcdistribution(resAx, resy, F);
            SSa = Math.Round(SSa, 3);
            SSe = Math.Round(SSe, 3);
            MSa = Math.Round(MSa, 3);
            MSe = Math.Round(MSe, 3);
            F = Math.Round(F, 3);
            p = Math.Round(p, 3);
        }
    }
}
