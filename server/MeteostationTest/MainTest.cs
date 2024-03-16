using Xunit;
using ServerMVC.Controllers;
using ServerMVC.Models;
using ServerMVC.Infrastructure.Statistics;

namespace ServerMVC.Test
{
    public class MeteostationTest
    {
        /// <summary>
        /// Тестирование метода ранжирования данных. Тест без повторяющихся значений.
        /// </summary>
        [Fact]
        public void RangeDataWithoutRepeat()
        {
            OneFactorData a = new OneFactorData(new double[] { 3, 8, 4, 5 });
            OneFactorData b = new OneFactorData(new double[] { 1, 6, 7, 0 });
            OneFactorData c = new OneFactorData(new double[] { 9, 2 });
            OneFactorData[] data = new OneFactorData[] { a, b, c };
            AnalysisController analysisController = new AnalysisController();
            OneFactorData[] rangedData = analysisController.RangeData(data);

            OneFactorData actualA = new OneFactorData(new double[] { 4, 9, 5, 6 });
            OneFactorData actualB = new OneFactorData(new double[] { 2, 7, 8, 1 });
            OneFactorData actualC = new OneFactorData(new double[] { 10, 3 });
            OneFactorData[] actualData = new OneFactorData[] { actualA, actualB, actualC };

            for (int i = 0; i < rangedData.Length; i++)
            {
                for (int j = 0; j < rangedData[i].Length; j++)
                    Assert.Equal(actualData[i][j], rangedData[i][j]);
            }
        }
        /// <summary>
        /// Тестирование метода ранжирования данных. Тест с повторяющимися значениями.
        /// </summary>
        [Fact]
        public void RangeDataWithRepaeat()
        {
            OneFactorData a = new OneFactorData(new double[] { 8, 9, 2, 2, 2 });
            OneFactorData b = new OneFactorData(new double[] { 3, 1, 4, 8, 1 });
            OneFactorData c = new OneFactorData(new double[] { 6, 5, 3, 1 });
            OneFactorData d = new OneFactorData(new double[] { 5, 1, 6 });
            OneFactorData[] data = new OneFactorData[] { a, b, c, d };
            AnalysisController analysisController = new AnalysisController();
            OneFactorData[] rangedData = analysisController.RangeData(data);

            OneFactorData actualA = new OneFactorData(new double[] { 15.5, 17, 6, 6, 6 });
            OneFactorData actualB = new OneFactorData(new double[] { 8.5, 2.5, 10, 15.5, 2.5 });
            OneFactorData actualC = new OneFactorData(new double[] { 13.5, 11.5, 8.5, 2.5 });
            OneFactorData actualD = new OneFactorData(new double[] { 11.5, 2.5, 13.5 });
            OneFactorData[] actualData = new OneFactorData[] { actualA, actualB, actualC, actualD };

            for (int i = 0; i < rangedData.Length; i++)
            {
                for (int j = 0; j < rangedData[i].Length; j++)
                    Assert.Equal(actualData[i][j], rangedData[i][j]);
            }
        }
        /// <summary>
        /// Верификация алгоритма однофакторного дисперсионного анализа на основе книги Доспехова Б.А. "Методика полевого опыта", на странице 223
        /// </summary>
        [Fact]
        public void Dospehov223page()
        {
            OneFactorData a = new OneFactorData(new double[] { 454, 470, 430, 500 });
            OneFactorData b = new OneFactorData(new double[] { 502, 550, 490, 507 });
            OneFactorData c = new OneFactorData(new double[] { 601, 670, 550, 607 });
            OneFactorData d = new OneFactorData(new double[] { 407, 412, 475, 402 });
            OneFactorData e = new OneFactorData(new double[] { 418, 470, 460, 412 });
            OneFactorData[] data = new OneFactorData[] { a, b, c, d, e };

            Anova anova = new Anova(data);
            Assert.Equal(489.35, anova.avgX, 1e-3);
            Assert.Equal(20, anova.n);
            Assert.Equal(86960.8, anova.SSa, 1e-3);
            Assert.Equal(17979.75, anova.SSe, 1e-3);
            Assert.Equal(104940.550, anova.SS, 1e-3);
            Assert.Equal(4, anova.dfA, 1e-3);
            Assert.Equal(15, anova.df, 1e-3);
            Assert.Equal(21740.2, anova.MSa, 1e-3);
            Assert.Equal(1198.65, anova.MSe, 1e-3);
            Assert.Equal(18.137, anova.F, 1e-3);
            Assert.Equal(3.06, anova.Fcrit, 1e-3);
            Assert.Equal(0, anova.p, 1e-3);
        }
    }
}
