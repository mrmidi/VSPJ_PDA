using System.Collections.ObjectModel;
using System.Text.Json;

namespace CV03_PART_3;

public partial class MainPage : ContentPage
{
    int count = 0;
    public String rawJson;

    List<SubjectsList> subjectsList = new List<SubjectsList>();
    
    // List<UsersSubjectsList> usersSubjectsList = new List<UsersSubjectsList>();
    ObservableCollection<UsersSubjectsList> usersSubjectsList = new ObservableCollection<UsersSubjectsList>();

    public class UsersSubjectsList
    {
        //public List<SubjectsList> subjectsList { get; set; }
        public string usersName { get; set; }
        public string usersAcronym { get; set; }
        public string usersCredits { get; set; }
    }
    public class SubjectsList
    {
        public string Name { get; set; }
        public string SubjectType { get; set; }
        public int Semester { get; set; }
        public int Credits { get; set; }
        public string Exam { get; set; }
        public string? Teacher { get; set; }


        public SubjectsList() { }
    }

    public MainPage()
    {
        InitializeComponent();
        LoadJson();
        subjectsList = JsonSerializer.Deserialize<List<SubjectsList>>(rawJson);
        SubjectListView.ItemsSource = subjectsList;
        //UserSubjectListView.ItemsSource = usersSubjectsList;
        //Initialize details
        detailsName.Text = subjectsList[0].Name;
        detailsType.Text = subjectsList[0].SubjectType;
        detailsSem.Text = subjectsList[0].Semester.ToString();
        detailsCred.Text = subjectsList[0].Credits.ToString();
        detailsCond.Text = subjectsList[0].Exam;
        detailsTeacher.Text = subjectsList[0].Teacher;
        detailsAcronym.Text = Acronym(subjectsList[0].Name);
        // Set Second ListView ItemsSource
        UserSubjectListView.ItemsSource = usersSubjectsList;
        // foreach (var subject in subjectsList)
        // {
        //     Console.WriteLine(subject.Name);
        // }
    }

    public void SetDetails()
    {
        var selectedSubject = SubjectListView.SelectedItem as SubjectsList;
        if (selectedSubject != null)
        {
            detailsName.Text = selectedSubject.Name;
            detailsType.Text = selectedSubject.SubjectType;
            detailsSem.Text = selectedSubject.Semester.ToString();
            detailsCred.Text = selectedSubject.Credits.ToString();
            detailsCond.Text = selectedSubject.Exam;
            detailsTeacher.Text = selectedSubject.Teacher;
            detailsAcronym.Text = Acronym(selectedSubject.Name);
        }
    }
    
    
    public String Acronym(String name)
    {
        String acronym = "";
        String[] words = name.Split(" ");
        foreach (var word in words)
        {
            if (word.Length > 3)
            {
                acronym += word[0];
            }
        }
        return acronym.ToUpper();
    }
    
    private async Task LoadJson()
    {
        try
        {
            //open json file from resources/raw folder
            using var stream = await FileSystem.OpenAppPackageFileAsync("subjects.json");
            using var reader = new StreamReader(stream);
            rawJson = reader.ReadToEnd();
        } catch (Exception ex)
        {
            rawJson = "";
        }
    }

    private void SubjectListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        //throw new NotImplementedException();
        SetDetails();
    }

    private void AddSubject(SubjectsList subject)
    {
        
        usersSubjectsList.Add(new UsersSubjectsList()
        {
            usersName = subject.Name,
            usersAcronym = Acronym(subject.Name),
            usersCredits = subject.Credits.ToString()
        });

    }

    private int CountCredits()
    {
        int credits = 0;
        if (usersSubjectsList.Count == 0)
            return 0;
        foreach (var subject in usersSubjectsList)
        {
            credits += int.Parse(subject.usersCredits);
        }
        return credits;
    }

    private void RemoveSubject(SubjectsList subject)
    {
        String sname = subject.Name;

        foreach (var usersubj in usersSubjectsList)
        {
            if (usersubj.usersName == sname)
            {
                usersSubjectsList.Remove(usersubj);
                break;
            }
        }
    }

    private void CheckBox_OnCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        //throw new NotImplementedException();
        var checkBox = sender as CheckBox;
        var item = checkBox.BindingContext as SubjectsList;
        if (checkBox.IsChecked)
        {
            AddSubject(item);
            
        }
        else
        {
            RemoveSubject(item);
        }

        creditsCount.Text = "Credits: " + CountCredits();
        Console.WriteLine("======= LIST =======");
        foreach (var usersubject in usersSubjectsList)
        {
            Console.WriteLine(usersubject.usersName);
        }
        Console.WriteLine("======= END =======");

        //UserSubjectListView.ItemsSource = usersSubjectsList;
    }

    public string[] MakeCsv()
    {
        string[] result = new string[] { };
        if (usersSubjectsList.Count == 0)
            return result;
        foreach (var subj in usersSubjectsList)
        {
            var name = subj.usersName;
            var acronym = subj.usersAcronym;
            var credits = subj.usersCredits;
            Array.Resize(ref result, result.Length + 1);
            result[result.Length - 1] = $"{name};{acronym};{credits}";
        }
        return result;
    }

    public string[] MakeJson()
    {
        string[] result = new string[] { };
        if (usersSubjectsList.Count == 0)
            return result;
        foreach (var subj in usersSubjectsList)
        {
            Array.Resize(ref result, result.Length + 1);
            result[result.Length - 1] = JsonSerializer.Serialize(subj);
            //result += JsonSerializer.Serialize(subj) + System.Environment.NewLine;
        }
        return result;
    }

    private void CSVButton_OnClicked(object sender, EventArgs e)
    {
        string[] csv = MakeCsv();
        foreach (var item in csv)
        {
            Console.WriteLine(item);
        }
        SaveFile(csv, "UserSubjects.csv");
    }

    private void JSONButton_OnClicked(object sender, EventArgs e)
    {
        string[] json = MakeJson();
        foreach (var item in json)
        {
            Console.WriteLine(item);
        }
        SaveFile(json, "UserSubjects.json");
    }
    
    
    private async Task SaveFile(string[] content, string filename)
    {
        await File.WriteAllLinesAsync(AppDomain.CurrentDomain.BaseDirectory + filename, content);
    }


}
