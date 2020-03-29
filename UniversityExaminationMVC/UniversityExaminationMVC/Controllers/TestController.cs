using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
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
            string date = DateTime.Now.Date.ToString();
            ViewBag.Date = date;
            List<Exam> exa = db.Exams.Where(x => true).ToList();
            List<Exam> exams = new List<Exam>();
            DateTime exdate;
            foreach (Exam x in exa)
            {

                exams.Add(x);
            }
            ViewBag.upExams = exams;
            List<Paper> papers = new List<Paper>();
            foreach (Paper pp in db.Papers.Where(x => true).ToList())
            {
                if (DateTime.Compare(DateTime.Now, pp.paperDate) < 0)
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
                Session["PaperID"] = id;
                List<Question> qq = new List<Question>();
                foreach (PaperQuestion pq in db.PaperQuestions.Where(x => x.PaperId == id).ToList())
                {
                    Question q = db.Questions.Where(x => x.QuestionId == pq.QuestionId).SingleOrDefault();
                    if (q != null)
                    {
                        qq.Add(q);
                    }
                }
                ViewBag.Questions = qq;
            }
          
            return View();
        }
        [HttpPost]
        public ActionResult GivePaper(FormCollection collection)
        {

            int id = (int)Session["PaperID"];
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

            foreach (Question ans in ViewBag.Questions) {
                string anss = collection[ans.QuestionId.ToString()];
                Console.WriteLine(anss);
          
            }

            return View();
        }
    }
}