using System;
using System.IO;
using System.Windows;

namespace AlinaZharkova
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            string surname = SurnameTextBox.Text;
            string algorithmicsGrade = AlgorithmicsTextBox.Text;
            string methodologyGrade = MethodologyTextBox.Text;
            string projectManagementGrade = ProjectManagementTextBox.Text;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(surname) ||
                string.IsNullOrWhiteSpace(algorithmicsGrade) || string.IsNullOrWhiteSpace(methodologyGrade) ||
                string.IsNullOrWhiteSpace(projectManagementGrade))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string filePath = "student_grades.txt";
            using (StreamWriter writer = File.AppendText(filePath))
            {
                writer.WriteLine($"Имя: {name}");
                writer.WriteLine($"Фамилия: {surname}");
                writer.WriteLine($"Алгоритмика: {algorithmicsGrade}");
                writer.WriteLine($"Методология: {methodologyGrade}");
                writer.WriteLine($"Управление IT-проектами: {projectManagementGrade}");
                writer.WriteLine(new string('-', 20));
            }

            MessageBox.Show("Данные успешно сохранены.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);

            ClearFields();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            NameTextBox.Clear();
            SurnameTextBox.Clear();
            AlgorithmicsTextBox.Clear();
            MethodologyTextBox.Clear();
            ProjectManagementTextBox.Clear();
        }
    }
}
