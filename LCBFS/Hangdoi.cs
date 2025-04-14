using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCBFS
{
   
    class Hangdoi
    {
        private int[] queueArray; // Mảng để lưu trữ các phần tử của hàng đợi
        private int capacity;     // Kích thước tối đa 
        private int frontIndex;   // Chỉ số của phần tử đầu hàng đợi
        private int rearIndex;    // Chỉ số của vị trí *tiếp theo* sẽ thêm phần tử mới vào
        private int count;        // Số lượng phần tử hiện có trong hàng đợi

       
        public Hangdoi(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentException("Capacity phải là số dương.", nameof(capacity));
            }
            this.capacity = capacity;
            this.queueArray = new int[capacity];
            this.frontIndex = 0; 
            this.rearIndex = 0;  
            this.count = 0;      
        }

        // Kiểm tra xem hàng đợi có rỗng không
        public bool isEmpty()
        {
            return this.count == 0;
        }

        // Kiểm tra xem hàng đợi có đầy không
        public bool isFull()
        {
            return this.count == this.capacity;
        }

        // Thêm một phần tử (đỉnh) vào cuối hàng đợi
        public void enQueue(int data)
        {
            // Kiểm tra nếu hàng đợi đầy
            if (isFull())
            {
                Console.WriteLine("Hang doi day, khong the them phan tu!");
                // Có thể ném ngoại lệ: throw new InvalidOperationException("Queue is full.");
                return; // Hoặc không làm gì cả/xử lý khác
            }

            // Thêm dữ liệu vào vị trí rearIndex
            this.queueArray[this.rearIndex] = data;

            // Cập nhật rearIndex để trỏ đến vị trí tiếp theo, sử dụng phép chia lấy dư (%)
            // để quay vòng lại đầu mảng nếu cần (tạo thành hàng đợi vòng)
            this.rearIndex = (this.rearIndex + 1) % this.capacity;

            // Tăng số lượng phần tử
            this.count++;
        }

        // Lấy và xóa phần tử khỏi đầu hàng đợi
        public int deQueue()
        {
            // Kiểm tra nếu hàng đợi rỗng
            if (isEmpty())
            {
                Console.WriteLine("Hang doi rong, khong the lay phan tu!");
                // Có thể ném ngoại lệ: throw new InvalidOperationException("Queue is empty.");
                return -1; // Trả về giá trị lỗi
            }

            // Lấy dữ liệu từ vị trí frontIndex
            int data = this.queueArray[this.frontIndex];

            // Cập nhật frontIndex để trỏ đến phần tử tiếp theo, quay vòng nếu cần
            this.frontIndex = (this.frontIndex + 1) % this.capacity;

            // Giảm số lượng phần tử
            this.count--;

            return data; // Trả về dữ liệu đã lấy
        }

        // (Tùy chọn) Xem phần tử ở đầu hàng đợi mà không xóa
        public int peek()
        {
            if (isEmpty())
            {
                Console.WriteLine("Hang doi rong, khong the xem phan tu!");
                // Có thể ném ngoại lệ: throw new InvalidOperationException("Queue is empty.");
                return -1; // Trả về giá trị lỗi
            }
            // Chỉ trả về phần tử ở đầu mà không thay đổi frontIndex hay count
            return this.queueArray[this.frontIndex];
        }

        // (Tùy chọn) Lấy số lượng phần tử hiện tại
        public int Count()
        {
            return this.count;
        }
    }
}