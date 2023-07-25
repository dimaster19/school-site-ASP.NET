namespace School43_ASP.NET.Models
{
    public class Pager
    {
        public int PageCount { get; }
        public int ItemCount { get; }
        public int StartPage { get; }
        public int EndPage { get; }
        public int CurrentPage { get; }
        public int ItemOnPage{ get; }


        public Pager()
        {

        }  

        public Pager(int totalItems, int page, int itemOnPage = 10)
        {
            PageCount = (int)Math.Ceiling((decimal)totalItems / itemOnPage);
            CurrentPage = page;

            StartPage = CurrentPage - 2;
            EndPage = CurrentPage + 2;

            if (StartPage <= 0)
            {
                EndPage = EndPage - StartPage + 1;
                StartPage = 1;

            }

            if (EndPage >= PageCount)
            {
                EndPage = PageCount;
                if (EndPage > 5)
                {
                    StartPage = EndPage - 4;
                }
            }

            ItemOnPage = itemOnPage;

    
        }


    }
}
