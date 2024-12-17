using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CBT_TestApp
{
    internal class Users
    {
        int duration = 2; // in minutes
        int totalSeconds = 0;
        List<User> users = new List<User>();
        User user;
        Question tempQuest;
        List<Question> questions = new List<Question>();
        Random randQuest = new Random();
        int[] questArray = new int[21];
        int count = 0;
        Thread threadA;





        public void Register()
        {
            try
            {
                Console.Write("Enter your first-name: ");
                string firstName = Console.ReadLine();
                Console.Write("Enter your last-name: ");
                string lastName = Console.ReadLine();

                users.Add(new User
                {
                    FirstName = firstName,
                    LastName = lastName
                });

                PrintDotAnimation();
                PrintMessage($"{firstName} {lastName} your details have been registered successfully!", true);
                PressEnterToContinue();
                Console.Clear();
                AppMenuOne();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Login()
        {
            try
            {
                Console.Write("Enter your username: ");
                string username = Console.ReadLine();
                Console.Write("Enter your Password: ");
                string password = Console.ReadLine();

                user = users.Find(x => x.FirstName == username && x.LastName == password);

                if (user != null)
                {
                    PrintMessage("Login Successful..", true);
                    PressEnterToContinueToSecondMenu();
                }
                else
                {
                    PrintMessage("Invalid login details.", false);
                    PressEnterToContinue();
                    Console.Clear();
                    AppMenuOne();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void AppMenuTwo()
        {
            Console.WriteLine("Are you ready to take the quiz..");
            Console.WriteLine("You have 20 questions to answer. Good luck!");
            Console.WriteLine($"The test will run for {duration} minutes. Timer starts immediately you press the enter button!");
            PressEnterToContinue();
            Console.Clear();
            IterateThroughQuest();
        }


        public void  AddQuestions()
        {
            questions.AddRange(new List<Question>
            {
                new Question(1,"Who is the current President of Nigeria?","A) Muhammadu Buhari","B) Goodluck Jonathan","C) Bola Ahmed Tinubu","D) Atiku Abubakar","C"),
                new Question(2,"What is the capital city of Nigeria?","A) Lagos","B) Abuja","C) Port Harcourt","D) Kano","B"),
                new Question(3,"What is Nigeria's currency?","A) Dollar","B) Cedi","C) Naira","D) Pound","C"),
                new Question(4,"Nigeria is a member of which regional organization?","A) African Union (AU)","B) ECOWAS","C) NATO","D) ASEAN","B"),
                new Question(5,"Which Nigerian artist won the Grammy Award in 2021?","A) Burna Boy","B) Wizkid","C) Davido","D) Tiwa Savage","A"),
                new Question(6,"Which year did Nigeria gain independence from British colonial rule?","A) 1958","B) 1960","C) 1963","D) 1970","B"),
                new Question(7,"What is the official language of Nigeria?","A) Hausa","B) Yoruba","C) English","D) Igbo","C"),
                new Question(8,"What is the largest ethnic group in Nigeria by population?","A) Hausa-Fulani","B) Yoruba","C) Igbo","D) Tiv","A"),
                new Question(9,"Which state in Nigeria is known as the \"Centre of Excellence\"?","A) Kano","B) Lagos","C) Ogun","D) Enugu","B"),
                new Question(10,"Which Nigerian city is referred to as the \"Coal City\"?","A) Jos","B) Abuja","C) Enugu","D) Calabar","C"),
                new Question(11,"What is Nigeria’s main export product?","A) Cocoa","B) Crude Oil","C) Gold","D) Palm Oil","B"),
                new Question(12,"Who is the current Chief Justice of Nigeria?","A) Olukayode Ariwoola","B) Tanko Muhammad","C) Walter Onnoghen","D) Mahmud Mohammed","A"),
                new Question(13,"Which Nigerian university is the oldest?","A) University of Lagos","B) University of Ibadan","C) Ahmadu Bello University","D) Obafemi Awolowo University","B"),
                new Question(14,"What is the slogan of Nigeria’s national carrier, Nigeria Air?","A) \"Bringing Africa Together\"","B) \"Proudly Nigerian\"","C) \"Fly Nigeria, Fly the World\"","D) \"The New Dawn of Travel\"","A"),
                new Question(15, "Which Nigerian state is the largest by landmass?","A) Niger","B) Borno","C) Kano","D) Lagos","B"),
                new Question(16, "What is the name of Nigeria's current Minister of Finance?","A) Zainab Ahmed","B) Wale Edun","C) Kemi Adeosun","D) Ngozi Okonjo-Iweala","B"),
                new Question(17, "Which Nigerian author won the Nobel Prize for Literature?", "A) Chinua Achebe", "B) Chimamanda Ngozi Adichie", "C) Wole Soyinka", "D) Ben Okri", "C"),
                new Question(18, "Which Nigerian state is known for its groundnut pyramids?", "A) Katsina", "B) Sokoto", "C) Kano", "D) Jigawa", "C"),
                new Question(19, "The National Youth Service Corps (NYSC) program in Nigeria was introduced in which year?", "A) 1967", "B) 1973", "C) 1980", "D) 1991", "B"),
                new Question(20, "Which Nigerian airport is the busiest in the country?", "A) Murtala Muhammed International Airport", "B) Nnamdi Azikiwe International Airport", "C) Port Harcourt International Airport", "D) Akanu Ibiam International Airport", "A")
            });

        }

        public void SetTimer()
        {
            string readingTime = "";
            totalSeconds = duration * 60;
            for (int i = 120; i > 1; i--)
            {
                readingTime = FormatTime(totalSeconds);
                Console.Write($"Time Remaining: {readingTime}");
                Thread.Sleep(1000); // Wait for 1 second
                ClearSpecificLine(1);
                totalSeconds--;
            }
        }

        static void ClearSpecificLine(int line)
        {
            // Move the cursor to the specified line and clear it
            Console.SetCursorPosition(0, line);
            Console.Write(new string(' ', Console.WindowWidth)); // Overwrite with spaces
            Console.SetCursorPosition(0, line); // Reset cursor position
        }

        public void ShowTimer()
        {
            Console.WriteLine("Time Remaining: " + FormatTime(totalSeconds));
        }
        public void IterateThroughQuest()
        {
            
            while (count != 10)
            {
                int questionSelector = randQuest.Next(1, 11);
                if (questArray.Contains(questionSelector))
                {
                    continue;
                }
                else
                {
                    var key = Console.ReadKey();
                    if (key.Key == ConsoleKey.Enter)
                    {
                        threadA = new Thread(SetTimer);
                        threadA.Start();
                    }
                    questArray[questionSelector] = questionSelector;
                    count += 1;
                    tempQuest = questions.Find(x => x.QuestID == questionSelector);
                    QuestionFormat(tempQuest.QuestID, tempQuest.CbtQuest, tempQuest.OptionA, tempQuest.OptionB, tempQuest.OptionC, tempQuest.OptionD, tempQuest.Answer);
                    if(totalSeconds < 1)
                    {
                        count = 10;
                        Console.WriteLine("Time is up! Your answers has been submitted.");
                        PrintReusltOfQuiz();
                    }
                }
            }
            
            PrintReusltOfQuiz();
        }
        string FormatTime(int totalSeconds)
        {
            int minutes = totalSeconds / 60;
            int seconds = totalSeconds % 60;
            return $"{minutes:D2}:{seconds:D2}";
        }
        private void PrintReusltOfQuiz()
        {
            user.Remark = $"Thank you {user.FirstName}{user.LastName} for participating in the Quiz, you scored {user.TotalScore} / 20.";
            PressEnterToContinue();
            AppMenuOne();
        }

        private void QuestionFormat(int questNumb, string question, string optionA, string optionB, string optionC, string optionD, string answer)
        {
            var key = Console.ReadKey();
            if(key.Key == ConsoleKey.Enter)
            {
                threadA = new Thread(SetTimer);
                threadA.Start();      
            } 
            Console.WriteLine($"Answered question {count}/20\n");

            Console.Write($"{questNumb}. {question}");
            Console.WriteLine("\n");
            Console.WriteLine($"{optionA}");
            Console.WriteLine($"{optionB}");
            Console.WriteLine($"{optionC}");
            Console.WriteLine($"{optionD}");

            Console.Write("Select your option choose either (A,B,C,D): ");
            string userAnswer = Console.ReadLine();
            userAnswer.ToUpper();
            if (userAnswer == null)
            {
                Console.WriteLine("You didn't select anything. Try again");
            }
            else
            {
                if (userAnswer == answer)
                {
                    user.TotalScore += 1;
                    PrintMessage($"Correct Answer", true);
                    PressEnterToContinue();
                    Console.Clear();
                }
                else
                {
                    PrintMessage("Wrong Answer", false);
                    PrintMessage($"The correct answer is: {answer}", true);
                    PressEnterToContinue();
                    Console.Clear();
                }
            }
        }

        public void PressEnterToContinue()
        {
            Console.Write("Press Enter to continue: ");
            Console.ReadLine();
            PrintDotAnimation();
        }

        public void PressEnterToContinueToSecondMenu()
        {
            Console.Write("Press Enter to continue: ");
            Console.ReadLine();
            PrintDotAnimation();
            AppMenuTwo();
        }

        public void AppMenuOne()
        {
            Console.WriteLine("-------Welcome to Dreamland School CBT Test Application------");
            Console.WriteLine("To take your test please login. Else Register if you don't have an account with us.");
            Console.WriteLine("Your first-name is your (Username) while your password is your (Surname)");
            Console.WriteLine("1. Register");
            Console.WriteLine("2. Login");
            Console.WriteLine("3. Exit the Application");
            try
            {
                Console.Write("Please choose and operation to perform: ");
                int.TryParse(Console.ReadLine(), out int choice);
                switch (choice)
                {
                    case 1:
                        Register();
                        break;
                    case 2:
                        Login();
                        break;
                    case 3:
                        PrintDotAnimation();
                        Environment.Exit(0);
                        break;
                    default:
                        PrintMessage("Invalid Option Selected", false);
                        PressEnterToContinue();
                        Console.Clear();
                        AppMenuOne();
                        break;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void PrintDotAnimation(int time = 10)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.Write(".");
                Thread.Sleep(200);
            }

            Console.WriteLine("\n");
        }

        public void PrintMessage(string message, bool status)
        {
            if (status == true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(message);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(message);
            }

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
