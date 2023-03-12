using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// InterViewAnswer 的摘要描述
/// </summary>
public class InterViewAnswer
{
    public InterViewAnswer()
    {
        Solution sol = new Solution();
        IList<IList<string>> solutions = sol.Answer(8);
    }

    public class Solution
    {
        public IList<IList<string>> Answer(int num)
        {
            List<IList<string>> result = new List<IList<string>>();
            List<int> queens = new List<int>();
            List<int> xydistince = new List<int>();
            List<int> xySum = new List<int>();
            CheckPoint(result, queens, xydistince, xySum, num);
            return result;
        }

        private void CheckPoint(List<IList<string>> result, List<int> queens, List<int> xydistince, List<int> xySum, int num)
        {
            int p = queens.Count;
            if (p == num)
            {
                var res = CreateBoard(queens);
                result.Add(res);
                return;
            }
            for (int q = 0; q < num; q++)
            {
                if (queens.IndexOf(q) == -1 && xydistince.IndexOf(p - q) == -1 && xySum.IndexOf(p + q) == -1)
                {
                    queens.Add(q);
                    xydistince.Add(p - q);
                    xySum.Add(p + q);

                    //用遞迴判斷是否寫入
                    CheckPoint(result, queens, xydistince, xySum, num);

                    queens.RemoveAt(queens.Count - 1);
                    xydistince.RemoveAt(xydistince.Count - 1);
                    xySum.RemoveAt(xySum.Count - 1);
                }
            }
        }

        private IList<string> CreateBoard(List<int> queens)
        {
            List<string> board = new List<string>();
            foreach (int q in queens)
            {
                List<string> list = new List<string>();
                //建立陣列
                for (int i = 0; i < queens.Count; i++)
                    list.Add(".");
                //變更陣列值
                list[q] = "Q";
                string res = "";
                //組合
                foreach (string str in list)
                    res += str;
                //加入
                board.Add(res);
            }
            return board;
        }
    }
}