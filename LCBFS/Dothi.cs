using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCBFS
{
    class Dothi
    {
        private int sodinh; //Số đỉnh của đồ thị
        private int start; //Đỉnh bắt đầu
        private int goal; //Đỉnh kết thúc
        private int[,] matran; //Ma trận trọng số

        public Dothi()
        {
            this.sodinh = -1;
            this.start = -1;
            this.matran = new int[12, 12]; //Có thể sử dụng 1 hàng nào đó nếu bạn muốn
            readDothi(); //Gọi phương thức đọc file .txt
        }

        public void readDothi() //Doc file tu o dia..
        {
            string textfile = @"D:/NguyenLeDuy/LCBFS/LCBFS/LCBFSInput.txt"; //Thay đổi đường dẫn phù hợp với ứng dụng của bạn
            if (File.Exists(textfile))
            {
                // Đọc tập tin dữ liệu theo từng dòng
                // Mỗi dòng lưu vào mảng lines[]
                string[] lines = File.ReadAllLines(textfile);
                string line0 = lines[0].Trim(); //Dòng thứ nhất cho biết số đỉnh
                this.sodinh = Convert.ToInt16(line0); //Chuyển kiểu dữ liệu. SD Parse nếu bạn không thích sd convert

                string line1 = lines[1].Trim();
                string[] tam = line1.Split(' ');
                this.start = Convert.ToInt16(tam[0]); //Dòng thứ 2 cho biết đỉnh Start và Goal
                this.goal = Convert.ToInt16(tam[1]);

                for (int i = 0; i < this.sodinh; i++) //Dòng thứ 3 trở về sau cho biết ma trận kề
                {
                    string linei = lines[i + 2].Trim();
                    //Console.WriteLine(linei);
                    string[] arr = linei.Split(' ');
                    for (int j = 0; j < this.sodinh; j++)
                    {
                        this.matran[i, j] = Convert.ToInt32(arr[j]);
                        //Console.Write(matran[i, j] + "  ");
                    }
                    //Console.WriteLine();
                }
            }
        }
        public void printDothi() //Hien thi noi dung da doc or noi dung cua do thi
        {
            System.Console.WriteLine("So dinh: {0}", sodinh);
            System.Console.WriteLine("Start: {0}; Goal: {1}", start, goal);
            for (int i = 0; i < this.sodinh; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < this.sodinh; j++)
                    Console.Write(this.matran[i, j] + "  ");
            }
        }


        //Danh muc các hàm Set/Get cho dữ liệu thành viên
        public int SoDinh
        {
            get { return sodinh; }
            set { sodinh = value; }
        }

        public int Start
        {
            get { return start; }
            set { start = value; }
        }
        public int Goal
        {
            get { return goal; }
            set { goal = value; }
        }

        public int[,] MaTran
        {
            get { return matran; }
            set { matran = value; }
        }
    }
}