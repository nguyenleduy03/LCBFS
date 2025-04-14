using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCBFS
{
    class LCBFSAlg
    {
        private Dothi dt;
        private Hangdoi q; 
        private int[] pre; 
        private int[] g; 
        static readonly int NIL = -5; //Giá trị để đánh dấu lúc quay lui

        public LCBFSAlg() 
        {
            //Khởi tạo các giá trị cho dữ liệu thành viên của LCBFSAlg
            dt = new Dothi();
            q = new Hangdoi(dt.SoDinh);
            pre = new int[dt.SoDinh];
            g = new int[dt.SoDinh];
           
            for (int i = 0; i < dt.SoDinh; i++)
            {
                pre[i] = -2; 
                g[i] = 0;  
            }
        
            pre[dt.Start] = NIL; 
            g[dt.Start] = 0; 
            q.enQueue(dt.Start);
        }

       
        public bool LCBFSearch()
        {
            bool kq = false; 
            int n = dt.SoDinh;
            int[,] matrix = dt.MaTran;

           
            while (!q.isEmpty())
            {
              
                int s = q.deQueue();
                if (s == -1) break;
                for (int s1 = 0; s1 < n; s1++)
                {
                   
                    if (matrix[s, s1] > 0)
                    {
                        int cost_s_s1 = matrix[s, s1]; // Chi phí cạnh (s, s1)
                        int new_g_s1 = g[s] + cost_s_s1; // Tính chi phí mới đến s1 qua s
                        if (pre[s1] == -2 || new_g_s1 < g[s1])
                        {
                            
                            pre[s1] = s;
                            // Đặt g(s1) := g(s) + Cost(s, s1) ---
                            g[s1] = new_g_s1;
                            //Thêm s1 vào Vk+1 ---
                            // Thêm vào hàng đợi để xét tiếp các đỉnh kề của s1
                            // Với hàng đợi mảng vòng, nếu đầy sẽ có thông báo lỗi từ enQueue
                            q.enQueue(s1);
                        }
                    }
                }
                // (k := k+1) 
            } // Kết thúc while

            // Kiểm tra xem đỉnh đích (Goal) đã được gán nhãn chưa (tức là pre[Goal] khác -2)
            if (pre[dt.Goal] != -2)
            {
                kq = true; // Đã tìm thấy đường đến Goal
            }
            // Nếu không, kq vẫn là false (giá trị khởi tạo)

            return kq; // Trả về true nếu tìm thấy Goal, false nếu không
        }



        public void printG()
        {
            Console.WriteLine("Tong chi phi: {0}", g[dt.Goal]);
           
        }

      
        public void printDuongdi()
        {
            if (pre[dt.Goal] == -2) // Kiểm tra xem có đến được Goal không
                Console.WriteLine("KHONG tim duoc duong di ");
            else
            {
                Console.Write("Duong di tim duoc: "); // Có thể sửa text tùy ý
                Stack<int> path = new Stack<int>(); // Dùng Stack để đảo ngược thứ tự
                int curr = dt.Goal;
                // Lần ngược từ Goal về Start dựa vào mảng pre
                while (curr != NIL) // NIL = -5, là giá trị gán cho pre[Start]
                {
                    path.Push(curr); // Đẩy đỉnh hiện tại vào stack

                    // Kiểm tra trước khi gán để tránh lỗi nếu pre[Start] không phải NIL
                    if (curr == dt.Start) break;

                    curr = pre[curr]; // Di chuyển đến đỉnh trước đó

                    // Bẫy lỗi nếu có vấn đề trong logic truy vết (không nên xảy ra)
                    if (curr == -2 && path.Peek() != dt.Start)
                    {
                        Console.Write("\nLoi logic khi truy vet duong di! Gap dinh chua duoc tham.");
                        return;
                    }
                }

                // In đường đi từ Stack (đã đúng thứ tự Start -> Goal)
                while (path.Count > 0)
                {
                    Console.Write(path.Pop());
                    if (path.Count > 0)
                        Console.Write(" -> ");
                }
                Console.WriteLine(); // Xuống dòng cho đẹp
            }
        }

        // --- Giữ nguyên Properties như trong video ---
        public Dothi MyGraph
        {
            get { return dt; }
            set { dt = value; }
        }
        // Property cho Hangdoi (có thể để get thôi nếu không muốn thay đổi queue từ bên ngoài)
        public Hangdoi MyQueue
        {
            get { return q; }
            // set { q = value; } // Bỏ set nếu không cần thiết
        }
    }
}