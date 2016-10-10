using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Configuration;

using System.Data;


    public class Student
    {
        //public Student()
        //{
        //    DBDataHelper.ConnectionString = ConfigurationManager.ConnectionStrings["TT15ConnectionString"].ToString();

        //}

        public int TTId { get; set; }
        public String Name { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public int PartnerId { get; set; }
        public string StudentNo { get; set; }
        public string Password { get; set; }
        public int GenderId { get; set; }
        public int BranchId { get; set; }
        public int YearId { get; set; }
        public int CollegeId { get; set; }
        public int IsT_ShirtRequired { get; set; }
        public int IsAccomodationRequired { get; set; }

        public College College { get; set; }
        public Branch Branch { get; set; }
     
       public Student()
       {
           College = new College();
           Branch = new Branch();
       }


     
       //public Student GetStudent(string emailid, string password, int id)
       //{
       //    Connect.ConnectTTTest();
       //    Connect connect;
       //    Connect c1;
       //    string q1 = "select Password from participants where EmailID = @email";
       //    string[] s1 = { "@email" };
           
       //    Student temp = null;
       //    c1 = new Connect(q1, s1, emailid);
       //    if (c1.ds.Tables[0].Rows.Count > 0)
       //    {
       //        if (PasswordHasher.VerifyHashedPassword(c1.ds.Tables[0].Rows[0][0].ToString(), password))
       //        {
       //            string q = "select participants.*,colleges.CollegeName,branches.BranchName from participants inner join colleges on participants.CollegeID = colleges.CollegeID inner join branches on participants.BranchID = branches.BranchID  where EmailID =@emailid";
       //            string[] s = { "@emailid", "@password" };
       //            connect = new Connect(q, s, emailid, PasswordHasher.HashPassword(password));
       //            if (connect.ds.Tables[0].Rows.Count == 1)
       //            {
       //                DataRow row = connect.ds.Tables[0].Rows[0];
       //                temp = new Student();
       //                temp.TTId = Convert.ToInt32(row[0]);
       //                temp.Name = row[1].ToString();
       //                temp.Email = emailid;
       //                temp.ContactNo = row[3].ToString();
       //                temp.PartnerId = Convert.ToInt32(row[4]);
       //                temp.StudentNo = row[5].ToString();
       //                temp.GenderId = Convert.ToInt32(row[7]);
       //                temp.YearId = Convert.ToInt32(row[9]);
       //                temp.BranchId = Convert.ToInt32(row[8]);
       //                temp.IsT_ShirtRequired = Convert.ToInt32(row[11]);
       //                temp.CollegeId = Convert.ToInt32(row[10]);
       //                temp.IsAccomodationRequired = Convert.ToInt32(row[12]);
       //                temp.College.CollegeId = Convert.ToInt32(row[10]);
       //                temp.College.CollegeName = row[13].ToString();
       //                temp.Branch.BranchId = Convert.ToInt32(row[8]);
       //                temp.Branch.BranchName = row[14].ToString();
       //                string q2 = "insert into eventregistrations(TTID,EventID,CurrentLevel) values (" + temp.TTId.ToString() + "," + id.ToString() + "," + 1 + ")";
       //                Connect c2 = new Connect(q2);
       //                return temp;
       //            }
       //            else
       //                return temp;
       //        }
       //        else
       //            return temp;
       //    }
       //    else
       //        return temp;





       //}

       //public Student GetStudent(string emailid, string password, int id)
       //{
       //    Connect.ConnectTTTest();
       //    Connect connect;
       //    Connect c1;
       //    string q1 = "select Password from participants where EmailID = @email";
       //    string[] s1 = { "@email" };

       //    Student temp = null;
       //    c1 = new Connect(q1, s1, emailid);
       //    if (c1.ds.Tables[0].Rows.Count > 0)
       //    {
       //        if (PasswordHasher.VerifyHashedPassword(c1.ds.Tables[0].Rows[0][0].ToString(), password))
       //        {
       //            string q = "select participants.*,colleges.CollegeName,branches.BranchName from participants inner join colleges on participants.CollegeID = colleges.CollegeID inner join branches on participants.BranchID = branches.BranchID  where EmailID =@emailid";
       //            string[] s = { "@emailid", "@password" };
       //            connect = new Connect(q, s, emailid, PasswordHasher.HashPassword(password));
       //            if (connect.ds.Tables[0].Rows.Count == 1)
       //            {
       //                DataRow row = connect.ds.Tables[0].Rows[0];
       //                temp = new Student();
       //                temp.TTId = Convert.ToInt32(row[0]);
       //                temp.Name = row[1].ToString();
       //                temp.Email = emailid;
       //                temp.ContactNo = row[3].ToString();
       //                temp.PartnerId = Convert.ToInt32(row[4]);
       //                temp.StudentNo = row[5].ToString();
       //                temp.GenderId = Convert.ToInt32(row[7]);
       //                temp.YearId = Convert.ToInt32(row[9]);
       //                temp.BranchId = Convert.ToInt32(row[8]);
       //                temp.IsT_ShirtRequired = Convert.ToInt32(row[11]);
       //                temp.CollegeId = Convert.ToInt32(row[10]);
       //                temp.IsAccomodationRequired = Convert.ToInt32(row[12]);
       //                temp.College.CollegeId = Convert.ToInt32(row[10]);
       //                temp.College.CollegeName = row[13].ToString();
       //                temp.Branch.BranchId = Convert.ToInt32(row[8]);
       //                temp.Branch.BranchName = row[14].ToString();

       //                string q3 = "select * from eventregistrations where TTID = "+temp.TTId.ToString();
       //                Connect c3 = new Connect();
       //                if(c3.ds.Tables[0].Rows.Count == 0)
       //                {
       //                string q2 = "insert into eventregistrations(TTID,EventID,CurrentLevel) values (" + temp.TTId.ToString() + "," + id.ToString() + "," + 1 + ")";
       //                Connect c2 = new Connect(q2);
       //                    }
       //                return temp;
       //            }
       //            else
       //                return temp;
       //        }
       //        else
       //            return temp;
       //    }
       //    else
       //        return temp;





       //}

       

    
}
