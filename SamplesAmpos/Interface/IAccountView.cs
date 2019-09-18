using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BumedianBM.Interface
{
  public  interface IAccountView
    {
      void LoadEvent();
      void LoadMaxMinNumber();
      Boolean Save();
      void New();
      void Print();
      Boolean Delete();
      bool RightNavigation();
      void LeftNavigation();
      string TextChanged();

    }   
  



}
