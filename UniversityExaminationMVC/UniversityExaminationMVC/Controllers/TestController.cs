﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using UniversityExaminationMVC.Models;

namespace UniversityExaminationMVC.Controllers
{
    public class TestController : Controller
    {
        private DataModelContext db = new DataModelContext();


        public void Authorize()
        {
            if (Session["UserId"] != null && Session["UserType"].Equals("Student"))
            {

                return;
            }
            else
            {
                Response.Redirect("/Login");
            }
        }
        // GET: Test
        public ActionResult Index()
        {
            Authorize();

            return View();
        }
        public ActionResult UpcomingExam()
        {
            Authorize();
            DateTime date = DateTime.Now;
            ViewBag.Date = date;
            List<Exam> exa = db.Exams.Where(x => true).ToList();
            List<Exam> exams = new List<Exam>();
            DateTime exdate;
            foreach (Exam x in exa)
            {

                TimeSpan ts = DateTime.Now - x.date;
                ViewBag.log = ts.TotalMinutes;
                if (ts.TotalMinutes  <= 15)
                {
                    exams.Add(x);
                }
            }
            ViewBag.upExams = exams;
            List<Paper> papers = new List<Paper>();
            foreach (Paper pp in db.Papers.Where(x => true).ToList())
            {

                TimeSpan ts = DateTime.Now - pp.paperDate;
                ViewBag.log = ts.TotalMinutes;
                if (ts.TotalMinutes <= 15)
                {
                    papers.Add(pp);
                }
            }

            ViewBag.upPapers = papers;
            return View();

        }

        public ActionResult PastExam()
        {
            Authorize();
            DateTime date = DateTime.Now.Date;
            ViewBag.Date = date;
            List<Exam> exa = db.Exams.Where(x => true).ToList();
            List<Exam> exams = new List<Exam>();
            DateTime exdate;
            foreach (Exam x in exa)
            {
                if (DateTime.Compare(DateTime.Now, x.date) > 0)
                {
                    exams.Add(x);
                }
            }
            ViewBag.upExams = exams;
            List<Paper> papers = new List<Paper>();
            foreach (Paper pp in db.Papers.Where(x => true).ToList())
            {
                if (DateTime.Compare(DateTime.Now, pp.paperDate) > 0)
                {
                    papers.Add(pp);
                }
            }

            ViewBag.upPapers = papers;
            return View();

        }
        public ActionResult GivePaper(int id)
        {
          
            Paper paper = db.Papers.Where(x => x.Id == id).SingleOrDefault();
            
            if (paper != null)
            {

                int dif = DateTime.Compare(paper.paperDate,DateTime.Now);

                TimeSpan ts =  DateTime.Now - paper.paperDate  ;
                ViewBag.log = ts.TotalMinutes;
                if (ts.TotalMinutes >= 0 && ts.TotalMinutes <=15)
                {

                    Session["PaperId"] = id;
                    List<Question> qq = new List<Question>();
                    foreach (PaperQuestion pq in db.PaperQuestions.Where(x => x.PaperId == id).ToList())
                    {
                        Question q = db.Questions.Where(x => x.QuestionId == pq.QuestionId).SingleOrDefault();
                        if (q != null)
                        {
                            qq.Add(q);
                        }
                    }
                    DateTime timerDate = paper.paperDate.AddMinutes(paper.Duration);
                    ViewBag.PaperDate = string.Format("{0:MMMM dd, yyyy HH:mm:ss}", timerDate);// paper.paperDate.Month +" "+paper.paperDate.Day+","+paper.paperDate.TimeOfDay ;
                    ViewBag.Questions = qq;
                    ViewBag.statusCode = 100;

                }
                else if(ts.TotalMinutes > 15)
                {
                    ViewBag.error = "You are late to attempt the paper ";
                    ViewBag.statusCode = 101;
                }
                else  {
                    ViewBag.error = "Papern has not started Time remaning ="+ts.TotalMinutes +" Minutes";
                    ViewBag.statusCode =101;
                }


            }
            else
            {
                ViewBag.error = "No paper found";
                ViewBag.statusCode = 102;
            }

            return View();
        }
   

        [HttpPost]
        public ActionResult GivePaper(FormCollection collection)
        {

            int id = (int)Session["PaperId"];
            List <Question> qq = new List<Question>();
            foreach (PaperQuestion pq in db.PaperQuestions.Where(x => x.PaperId == id).ToList())
            {
                Question q = db.Questions.Where(x => x.QuestionId == pq.QuestionId).SingleOrDefault();
                if (q != null)
                {
                    qq.Add(q);
                }
            }
            ViewBag.Questions = qq;

            string Submition = "";
            foreach (Question ans in ViewBag.Questions) {
                Submition += ans.Description + "$";

                string anss = collection[ans.QuestionId.ToString()];
                Submition += anss + "$";

                
            }
            PaperScore ps = new PaperScore();
            ps.Student_Id = (int)Session["UserId"];
            ps.Paper_Id = (int)Session["PaperId"];
            ps.Submition = Encoding.ASCII.GetBytes(Submition);
            db.PaperScores.Add(ps);
            db.SaveChanges();
            Response.Redirect("/Test/CloseWindow");
            return View();
        }

        public ActionResult ViewResult(int id) {

            int stuid = (int)Session["UserId"];
            PaperScore ps= db.PaperScores.Where(x => x.Paper_Id == id && x.Student_Id == stuid).SingleOrDefault();
            Paper p = db.Papers.Where(x => x.Id == id).SingleOrDefault();

            if (ps != null)
            {
                ViewBag.PaperScore = ps;
                ViewBag.Paper=p;
            }
            else {
                ViewBag.error = "You Have Not Attended This Paper";
            }

            return View();
        }
        public ActionResult Result() {
             List<Exam> exa = db.Exams.Where(x => true).ToList();
            ViewBag.upExams = exa;
            return View();

        }

        public ActionResult ExamResult(int id) {

            Exam ex=db.Exams.Where(x => x.Exam_Id == id).SingleOrDefault();
            if (ex != null)
            {
                int exid = ex.Exam_Id;
                List<Paper> lipaper = db.Papers.Where(x => x.exam.Exam_Id == exid).ToList();
                List < PaperScore > lips= new List<PaperScore>();
                int usid = (int)Session["UserId"];
                foreach (Paper p in lipaper) {

                   PaperScore ps=db.PaperScores.Where(x => x.Paper_Id == p.Id &&x.Student_Id==usid).SingleOrDefault();
                    if (ps != null) {
                        lips.Add(ps);
                    }
                }

                ViewBag.Exam = ex;
                ViewBag.Papers = lipaper;
                ViewBag.PaperScore = lips;
            }
            else {
            }
            return View();
        }



        public ActionResult CloseWindow() {

            return View();
        }
    }
}