using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PsihologARM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
   public partial class MainWindow : Window
    {
        public List<QuestionTest> Questions_test_list = new List<QuestionTest>();
        public DataTable table_visualed = new DataTable();
        private string selected_test { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            table_visualed.Columns.Add("Номер", typeof(int));
            table_visualed.Columns.Add("Вопрос", typeof(string));
            table_visualed.Columns.Add("Решение", typeof(bool));
            table_visualed.Columns["Номер"].ReadOnly = true;
            table_visualed.Columns["Вопрос"].ReadOnly = true;
            tbl_tests.ItemsSource = table_visualed.DefaultView;
            tbl_tests.CanUserDeleteRows = false;
            tbl_tests.CanUserAddRows = false;
            selected_test = "rb_NPU";
        }

        private void _func_Start_Test(string filename)
        {
            _func_Read_Test_from_File(filename);
            for (int j = 0; j < Questions_test_list.Count; j++)
            {
                table_visualed.Rows.Add(Questions_test_list[j].number.ToString(),
                    Questions_test_list[j].question.ToString(), (bool) Questions_test_list[j].answer);
            }

            tbl_tests.ItemsSource = table_visualed.DefaultView;
        }

        private void _func_Read_Test_from_File(string filename)
        {
            Questions_test_list.Clear();
            table_visualed.Clear();
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
                MessageBox.Show("Файл опросника не найден!");
                //Close();
            }
        }

        private void Btn_ResultTest_OnClick(object sender, RoutedEventArgs e)
        {
            bool validFlag = false;
            int i = 0;
            foreach (DataRow row in table_visualed.Rows)
            {
                Questions_test_list[i].answer = (bool) row[2];
                i++;
            }

            switch (selected_test)
            {
                case "rb_NPU":
                   var results_interpretation = new Results_Interpretation(Questions_test_list);
                    if (!results_interpretation.func_Credibility_test())
                    {
                        MessageBox.Show($"Тест не достоверен");
                    }
                    else
                    {
                        MessageBox.Show($"Тест достоверен");
                        var test_result_window = new Test_Result_Window();
                        string header_temp = "";
                        string message_temp = "";

                        var flow_result_document = new FlowDocument();
                        
                        results_interpretation.func_Interpretation_Adaptive_abilities(ref header_temp,
                            ref message_temp);
                        string result_testing = header_temp + "\n" + message_temp;
                        flow_result_document.Blocks.Add(new Paragraph(new Run(result_testing)));
                        
                        results_interpretation.func_Interpretation_Neuropsychological_steadiness(ref header_temp, ref message_temp);
                        result_testing = header_temp + "\n" + message_temp;
                        flow_result_document.Blocks.Add(new Paragraph(new Run(result_testing)));
                        
                        results_interpretation.func_Interpretation_Communication_features(ref header_temp,
                            ref message_temp);
                        result_testing = header_temp + "\n" + message_temp;
                        flow_result_document.Blocks.Add(new Paragraph(new Run(result_testing)));
                        
                        results_interpretation.func_Interpretation_Moral_normativity(ref header_temp,
                            ref message_temp);
                        result_testing = header_temp + "\n" + message_temp;
                        flow_result_document.Blocks.Add(new Paragraph(new Run(result_testing)));
                        
                        results_interpretation.func_Interpretation_Suicide_risk(ref header_temp, ref message_temp);
                        result_testing = header_temp + "\n" + message_temp;
                        flow_result_document.Blocks.Add(new Paragraph(new Run(result_testing)));
                        
                        result_testing = "Д = " + results_interpretation.Credibility + " АС = " +
                                         results_interpretation.Adaptive + " ST= " + results_interpretation.stan_Adaptive
                                         + " НПУ = " + results_interpretation.Neuropsychological + " ST = " +
                                         results_interpretation.stan_Neuropsychological + "\n КО = " +
                                         results_interpretation.Communication + " ST = " +
                                         results_interpretation.stan_Communication + " МН = "
                                         + results_interpretation.Moral_normativity + " ST = " +
                                         results_interpretation.stan_Moral_normativity + " СР = " +
                                         results_interpretation.Suicide_risk + " ST = " +
                                         results_interpretation.stan_Suicide_risk;
                        flow_result_document.Blocks.Add(new Paragraph(new Run(result_testing)));
                        test_result_window.TextBox_result.Document = flow_result_document;
                        test_result_window.Show();
                        
                    }

                    break;
                case "rb_Aizenc":
                    var aizenc_test_interpretation = new Aizenc_test_Interpretation(Questions_test_list);
                    int index_Credibility = 4;
                    aizenc_test_interpretation.func_Credibility_test(ref index_Credibility);
                    switch (index_Credibility)
                    {
                        case 2:
                            MessageBox.Show("Тест не достоверен! \n Необходимо пройти тест заново.");
                            validFlag = false;
                            break;
                        case 1:
                            MessageBox.Show("Тест сомнителен! \n Вероятно, результат будет не совсем достоверен.");
                            validFlag = true;
                            break;
                        case 0:
                            MessageBox.Show("Тест достоверен!");
                            validFlag = true;
                            break;
                    }

                    if (validFlag)
                    {
                        int extraversion = 0;
                        int neyrotizm = 0;
                        aizenc_test_interpretation._func_Emotional_Stability(ref neyrotizm);
                        aizenc_test_interpretation._func_Extraversion_Introversion(ref extraversion);
                        MessageBox.Show(
                            $"Сообщение-заглушка. \n Тест Айзенка. \n Значение переменной Нейротизм {neyrotizm} \n" +
                            $"Значение переменной Экстраверсия {extraversion}");
                        // Заглушка...
                    }

                    break;
            }
        }

        private void Btn_ClearTest_OnClick(object sender, RoutedEventArgs e)
        {
            foreach (DataRow row in table_visualed.Rows)
            {
                row[2] = false;
            }
        }

        private void Btn_LoadTest_OnClick(object sender, RoutedEventArgs e)
        {
            string filename = "questions.txt";

            foreach (Object _object in main_stack_panel.Children)
            {
                var rb = _object as RadioButton;
                if (rb != null)
                {
                    if (rb.GroupName == "TestSelecting" & rb.IsChecked == true)
                    {
                        selected_test = rb.Name.ToString();
                    }
                }
            }

            switch (selected_test)
            {
                case "rb_NPU":
                    filename = "questions.txt";
                    break;
                case "rb_Aizenc":
                    filename = "aizenc_questions.txt";
                    break;
            }


            _func_Start_Test(filename);
        }
    }
}