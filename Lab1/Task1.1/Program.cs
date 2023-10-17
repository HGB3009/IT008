namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Shape> shapes = new List<Shape>();
            Random random = new Random();

            Console.Write("Nhap so hinh ban muon tao: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                int shapeType = random.Next(1, 5);

                Console.Write($"Nhap ten cho hinh thu {i}: ");
                string name = Console.ReadLine();
                Console.Write($"Nhap vi tri cho hinh thu {i}: ");
                string position = Console.ReadLine();

                if (shapeType == 1)
                {
                    Console.WriteLine("Hinh duoc chon la hinh chu nhat");
                    Console.Write("Nhap chieu rong: ");
                    double width = double.Parse(Console.ReadLine());
                    Console.Write("Nhap chieu cao: ");
                    double height = double.Parse(Console.ReadLine());
                    shapes.Add(new Rectangle(name, position, width, height));
                }
                else if (shapeType == 2)
                {
                    Console.WriteLine("Hinh duoc chon la hinh tron");
                    Console.Write("Nhap ban kinh: ");
                    double radius = double.Parse(Console.ReadLine());
                    shapes.Add(new Circle(name, position, radius));
                }
                else if (shapeType == 3)
                {
                    Console.WriteLine("Hinh duoc chon la hinh tam giac");
                    Console.Write("Nhap chieu dai canh co so: ");
                    double BaSe = double.Parse(Console.ReadLine());
                    Console.Write("Nhap chieu cao: ");
                    double triangleHeight = double.Parse(Console.ReadLine());
                    shapes.Add(new Triangle(name, position, BaSe, triangleHeight));
                }
                if (shapeType == 4)
                {
                    Console.WriteLine("Hinh duoc chon la hinh vuong");
                    Console.Write("Nhap chieu dai canh: ");
                    double side = double.Parse(Console.ReadLine());
                    shapes.Add(new Square(name, position, side));
                }
            }

            Console.WriteLine("\nThong tin ve cac hinh da tao:");
            for (int i= 0;i < shapes.Count; i++)
            {
                Console.WriteLine($"Thong tin hinh thu {i + 1}: ");
                shapes[i].Draw();
                Console.WriteLine($"Dien tich cua hinh: {shapes[i].Area()}\n");
            }
        }
    }
}