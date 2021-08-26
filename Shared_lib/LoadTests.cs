using System;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;

namespace Shared_lib
{
    public static class LoadTests
    {
        public static void _func_Start_Test(string filename, ObservableCollection<QuestionTest> Questions_test_list, DataTable table_visualed)
        {
            _func_Read_Test_from_File(filename, Questions_test_list);
            for (int j = 0; j < Questions_test_list.Count; j++)
            {
                table_visualed.Rows.Add(Questions_test_list[j].number.ToString(),
                    Questions_test_list[j].question.ToString(), (bool) Questions_test_list[j].answer);
            }

            
        }

        private static void _func_Read_Test_from_File(string filename, ObservableCollection<QuestionTest> Questions_test_list)
        {
           
            try
            {
                using (var fs_read_sw = new StreamReader(filename))
                {
                    int i = 0;
                    do
                    {
                        i++;
                        Questions_test_list.Add(new QuestionTest((int) i, fs_read_sw.ReadLine(), false));
                    } while (!fs_read_sw.EndOfStream);

                    fs_read_sw.Close();
                }
            }
            catch
            {
                throw new Exception("Файл опросника не найден!");
                //Close();
            }
        }
    }
}