using System;
using System.Diagnostics;
using System.IO;
using System.Transactions;

namespace Assessment2DLList
{
    internal class Program
    {
        public static DLList DLList = new DLList();

        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                string filesize = ""; // Initialize the variable outside the if-else blocks                                                      -----note re-did my menu using AI
                                                                                                                                                 
                int opt = 0;
                Console.WriteLine("Choose File size");
                Console.WriteLine("Press 1 for 1000");
                Console.WriteLine("Press 2 for 5000");
                Console.WriteLine("Press 3 for 10000");
                Console.WriteLine("Press 4 for 15000");
                Console.WriteLine("Press 5 for 20000");
                Console.WriteLine("Press 6 for 25000");
                Console.WriteLine("Press 7 for 30000");
                Console.WriteLine("Press 8 for 35000");
                Console.WriteLine("Press 9 for 40000");
                Console.WriteLine("Press 10 for 45000");
                Console.WriteLine("Press 11 for 50000");
                opt = int.Parse(Console.ReadLine());

                if (opt >= 1 && opt <= 11)
                {
                    if (opt == 1)
                    {
                        filesize = "1000";
                    }
                    else if (opt == 2)
                    {
                        filesize = "5000";
                    }
                    else if (opt == 3)
                    {
                        filesize = "10000";
                    }
                    else if (opt == 4)
                    {
                        filesize = "15000";
                    }
                    else if (opt == 5)
                    {
                        filesize = "20000";
                    }
                    else if (opt == 6)
                    {
                        filesize = "25000";
                    }
                    else if (opt == 7)
                    {
                        filesize = "30000";
                    }
                    else if (opt == 8)
                    {
                        filesize = "35000";
                    }
                    else if (opt == 9)
                    {
                        filesize = "40000";
                    }
                    else if (opt == 10)
                    {
                        filesize = "45000";
                    }
                    else if (opt == 11)
                    {
                        filesize = "50000";
                    }
                    else
                    {
                        Console.WriteLine("Error input value: 1 -> 11");
                    }

                    Stopwatch stopwatch = Stopwatch.StartNew();
                    int counter = 0;
                    string Myline;
                    string Myfolder = @"../ordered/";
                    string MyFile = filesize + "-words.txt";
                    string path = Path.Combine(Myfolder, MyFile);

                    System.IO.StreamReader FileContent = new System.IO.StreamReader(path);
                    while ((Myline = FileContent.ReadLine()) != null)
                    {
                        if (!Myline.Contains("#") && !string.IsNullOrWhiteSpace(Myline))
                        {
                            DLList.AddToEnd(Myline);
                            counter++;
                        }
                    }

                    bool fileManipulationExit = false;
                    while (!fileManipulationExit)
                    {
                        Console.WriteLine("File has been read. Choose file manipulation option:");
                        Console.WriteLine("Press 1 for delete Operation");
                        Console.WriteLine("Press 2 for find Operation");
                        Console.WriteLine("Press 3 for ToPrint");
                        Console.WriteLine("Press 4 for Inserting Word");
                        Console.WriteLine("Press 0 to exit to file size selection");

                        int optManipulation = int.Parse(Console.ReadLine());

                        // Perform the selected manipulation operation
                        switch (optManipulation)
                        {
                            case 1:
                                Console.WriteLine("Insert Node to Delete: ");
                                string NodeToRemove = Console.ReadLine();
                                Console.WriteLine(DLList.RemoveNode(NodeToRemove));
                                stopwatch.Start();
                                DLList.RemoveNode(NodeToRemove); 
                                stopwatch.Stop();
                                Console.WriteLine("\n");
                                TimeSpan timeSpan1 = stopwatch.Elapsed;
                                Console.WriteLine("-Time Taken to perfrom delete operation-");
                                Console.WriteLine("Time: " + timeSpan1.ToString(@"mm\:ss\.fffffff") + " {m:ss} ");
                                Console.WriteLine("\n");
                             
                                break;
                            case 2:
                                Console.WriteLine("Insert Word To Search:");
                                string NodeToFind = Console.ReadLine();
                                stopwatch.Start();
                                Console.WriteLine(DLList.Find(NodeToFind));
                                stopwatch.Stop();
                                Console.WriteLine("\n");
                                TimeSpan timeSpan2 = stopwatch.Elapsed;
                                Console.WriteLine("-Time Taken to perfrom find operation-");
                                Console.WriteLine("Time: " + timeSpan2.ToString(@"mm\:ss\.fffffff") + " {m:ss} ");
                                Console.WriteLine("\n");

                                break;
                            case 3:
                                stopwatch.Start();
                                Console.WriteLine(DLList.ToPrint());      
                                stopwatch.Stop();
                                Console.WriteLine("Words inserted: " + counter + "\n");
                                TimeSpan timeSpan3 = stopwatch.Elapsed;         
                                Console.WriteLine("-Time Taken to perfrom insert-");
                                Console.WriteLine("Time: " + timeSpan3.ToString(@"mm\:ss\.fffffff") + " {m:ss} ");
                                Console.WriteLine("\n");
                                break;
                            case 4:
                                Console.WriteLine("Enter Word to input into the List:");
                                string WordInsertAfter = Console.ReadLine();
                                stopwatch.Start();
                                DLList.AddToFront(WordInsertAfter);
                                stopwatch.Stop();
                                TimeSpan timeSpan4 = stopwatch.Elapsed;
                                Console.WriteLine("-Time Taken to perfrom insert-");
                                Console.WriteLine("Time: " + timeSpan4.ToString(@"mm\:ss\.fffffff") + " {m:ss} ");
                                Console.WriteLine("\n");

                                break;

                            case 0:
                                fileManipulationExit = true;
                                break;
                            default:
                                Console.WriteLine("Invalid option. Press 1, 2, 3, or 0.");
                                break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid option. Please select a valid file size.");
                }

                Console.WriteLine("Press 1 to continue with file size selection or 0 to exit the program");
                int optContinue = int.Parse(Console.ReadLine());
                if (optContinue == 0)
                {
                    exit = true;
                }
            }
        }
    }
}