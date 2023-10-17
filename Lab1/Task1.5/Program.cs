namespace Task5
{
    class Program
    {
        static void Main(string[] args) 
        {
            Console.Write("Nhap duong dan cua thu muc: ");
            string folderPath = Console.ReadLine();

            if (Directory.Exists(folderPath))
            {
                Console.WriteLine("Danh sach cac tep tin trong thu muc:");
                string[] files = Directory.GetFiles(folderPath);
                foreach (string file in files)
                {
                    Console.WriteLine(Path.GetFileName(file));
                }
            }
            else
            {
                Console.WriteLine("Thu muc khong ton tai.");
            }
        }
    }
}