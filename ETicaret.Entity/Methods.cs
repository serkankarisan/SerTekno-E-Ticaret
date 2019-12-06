using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Entity
{
    public class Methods
    {
        public static string CapitalizeText(string OldText)
        {
            string NewText = "";
            if (!string.IsNullOrEmpty(OldText))
            {
                if (OldText.Contains('.'))
                {
                    string[] TextArray = OldText.Split('.');
                    foreach (string TextItem in TextArray)
                    {
                        string NewTextItem;
                        if (!string.IsNullOrEmpty(TextItem))
                        {
                            NewTextItem = TextItem.TrimStart().Substring(0, 1).ToUpper() + TextItem.TrimStart().Substring(1).ToLower();
                        }
                        else
                        {
                            NewTextItem = TextItem;
                        }
                        if (NewText == "")
                        {
                            NewText += NewTextItem;
                        }
                        else
                        {
                            NewText += ". " + NewTextItem;
                        }
                    }
                }
                else
                {
                    if (OldText.Contains(' '))
                    {
                        string[] TextArray = OldText.Split(' ');
                        foreach (string TextItem in TextArray)
                        {
                            string NewTextItem;
                            if (!string.IsNullOrEmpty(TextItem))
                            {
                                NewTextItem = TextItem.TrimStart().Substring(0, 1).ToUpper() + TextItem.TrimStart().Substring(1).ToLower();
                            }
                            else
                            {
                                NewTextItem = TextItem;
                            }
                            if (NewText == "")
                            {
                                NewText += NewTextItem;
                            }
                            else
                            {
                                NewText += " " + NewTextItem;
                            }
                        }
                    }
                    else
                    {
                        NewText = OldText.TrimStart().Substring(0, 1).ToUpper() + OldText.TrimStart().Substring(1).ToLower();
                    }

                }
            }
            else
            {
                NewText = OldText;
            }
            return NewText;
        }

        public static string CapitalizePropertyText(string OldText)
        {
            string NewText = "";
            if (!string.IsNullOrEmpty(OldText))
            {
                if (OldText.Contains(','))
                {
                    string[] TextArrayFirst = OldText.Split(',');
                    foreach (string TextItemFirst in TextArrayFirst)
                    {
                        string NewTextItemFirst = "";
                        if (TextItemFirst.Contains(':'))
                        {
                            string[] TextArraySecond = TextItemFirst.Split(':');
                            foreach (string TextItemSecond in TextArraySecond)
                            {
                                string NewTextItemSecond;
                                if (!string.IsNullOrEmpty(TextItemSecond))
                                {
                                    NewTextItemSecond = TextItemSecond.TrimStart().Substring(0, 1).ToUpper() + TextItemSecond.TrimStart().Substring(1).ToLower();
                                }
                                else
                                {
                                    NewTextItemSecond = TextItemSecond;
                                }
                                if (NewTextItemFirst == "")
                                {
                                    NewTextItemFirst += NewTextItemSecond;
                                }
                                else
                                {
                                    NewTextItemFirst += ":" + NewTextItemSecond;
                                }
                            }
                        }
                        else
                        {
                            NewTextItemFirst = TextItemFirst.TrimStart().Substring(0, 1).ToUpper() + TextItemFirst.TrimStart().Substring(1).ToLower();
                        }
                        if (NewText == "")
                        {
                            NewText += NewTextItemFirst;
                        }
                        else
                        {
                            NewText += ", " + NewTextItemFirst;
                        }
                    }
                }
                else
                {
                    if (OldText.Contains(':'))
                    {
                        string[] TextArray = OldText.Split(':');
                        foreach (string TextItem in TextArray)
                        {
                            string NewTextItem;
                            if (!string.IsNullOrEmpty(TextItem))
                            {
                                NewTextItem = TextItem.TrimStart().Substring(0, 1).ToUpper() + TextItem.TrimStart().Substring(1).ToLower();
                            }
                            else
                            {
                                NewTextItem = TextItem;
                            }
                            if (NewText == "")
                            {
                                NewText += NewTextItem;
                            }
                            else
                            {
                                NewText += ":" + NewTextItem;
                            }
                        }
                    }
                }
            }
            else
            {
                NewText = OldText;
            }
            return NewText;
        }
    }
}
