using Lab6.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace Lab6
{
    public partial class RegisterCourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string studentName = "";
            string studentType = "";
            int totalCourseHours = 0;
            int selectedCourseCount = 0;
            string[] selectedCourseCodes = new string[8];

            if (IsPostBack)
            {
                lblNameError.Visible = false;
                lblStudentTypeError.Visible = false;
                lblCourseError.Visible = false;
                lblMessage.Visible = false;
                lblSelectionError.Visible = false;

                lblNameError.Text = "";
                lblStudentTypeError.Text = "";
                lblCourseError.Text = "";
                lblMessage.Text = "";

                if (txtStudentName.Text == "" || string.IsNullOrEmpty(txtStudentName.Text))
                {
                    lblNameError.Visible = true;
                    lblNameError.Text = "You must enter a name!" + "<br/>";
                }
                else
                {
                    studentName = txtStudentName.Text;
                }

                bool isStudentTypeSelected = false;

                foreach (ListItem studentTypeItem in rblStudentType.Items)
                {
                    if (studentTypeItem.Selected)
                    {
                        studentType = studentTypeItem.Value;
                        isStudentTypeSelected = true;
                        break;
                    }
                }

                if (!isStudentTypeSelected)
                {
                    lblStudentTypeError.Text = "Please select student type!" + "<br/>";
                    lblStudentTypeError.Visible = true;
                    studentType = "";
                }

                bool isCourseSelected = false;

                foreach (ListItem courseItem in cbCourseSelection.Items)
                {
                    if (courseItem.Selected)
                    {
                        isCourseSelected = true;
                        break;
                    }
                }

                if (!isCourseSelected)
                {
                    lblCourseError.Text = "Please select at least one course!" + "<br/>";
                    lblCourseError.Visible = true;
                }
                else
                {
                    foreach (ListItem courseItem in cbCourseSelection.Items)
                    {
                        if (courseItem.Selected)
                        {
                            selectedCourseCodes[selectedCourseCount] = courseItem.Value;
                            selectedCourseCount += 1;

                            // Calculate total course hours
                            switch (courseItem.Text)
                            {
                                case "Introduction to Database Systems - 4 hours/week":
                                    totalCourseHours += 4;
                                    break;
                                case "Web Programming II - 2 hours/week":
                                    totalCourseHours += 2;
                                    break;
                                case "Web Programming Language I - 5 hours/week":
                                    totalCourseHours += 5;
                                    break;
                                case "Web Imaging and Animations - 2 hours/week":
                                    totalCourseHours += 2;
                                    break;
                                case "Network Operating System - 1 hours/week":
                                    totalCourseHours += 1;
                                    break;
                                case "Data Warehouse Design - 3 hours/week":
                                    totalCourseHours += 3;
                                    break;
                                case "Advance Database topics - 1 hours/week":
                                    totalCourseHours += 1;
                                    break;
                            }
                        }
                    }

                    lblMessage.Visible = true;
                    lblMessage.Text = $"Course count: {selectedCourseCount} / Total course hours: {totalCourseHours}" + "<br/>";
                }

                if (studentType == "Full Time" && totalCourseHours > 16)
                {
                    lblSelectionError.Text = "Full Time must not exceed 16 hours!" + "<br/>";
                    lblSelectionError.Visible = true;
                }
                else if (studentType == "Part Time" && selectedCourseCount > 3)
                {
                    lblSelectionError.Text = "Part Time cannot exceed 3 courses" + "<br/>";
                    lblSelectionError.Visible = true;
                }
                else if (studentType == "Co-op" && (selectedCourseCount > 2 || totalCourseHours > 4))
                {
                    lblSelectionError.Text = "Co-op cannot exceed 2 courses or 4 hours/week";
                    lblSelectionError.Visible = true;
                }

                if (lblNameError.Text == "" &&
                    lblStudentTypeError.Text == "" &&
                    lblCourseError.Text == "" &&
                    lblSelectionError.Text == "")
                {
                    Table mainTable = new Table();
                    mainTable.ID = "tblMainTable";

                    TableHeaderRow mainRow = new TableHeaderRow();
                    TableHeaderCell courseCodeHeader = new TableHeaderCell();
                    courseCodeHeader.Text = "Course Code";

                    TableHeaderCell courseTitleHeader = new TableHeaderCell();
                    courseTitleHeader.Text = "Course Title";

                    TableHeaderCell weeklyHoursHeader = new TableHeaderCell();
                    weeklyHoursHeader.Text = "Weekly Hours";

                    courseCodeHeader.Attributes["style"] = "font-size: 13px;" +
                                                           "padding: 8px;" +
                                                           "background: #b9c9fe;" +
                                                           "font-weight: normal;" +
                                                           "border-top: 4px solid #aabcfe;" +
                                                           "border-bottom: 1px solid #fff;" +
                                                           "color: #039;";

                    courseTitleHeader.Attributes["style"] = "font-size: 13px;" +
                                                            "padding: 8px;" +
                                                            "background: #b9c9fe;" +
                                                            "font-weight: normal;" +
                                                            "border-top: 4px solid #aabcfe;" +
                                                            "border-bottom: 1px solid #fff;" +
                                                            "color: #039;";

                    weeklyHoursHeader.Attributes["style"] = "font-size: 13px;" +
                                                             "padding: 8px;" +
                                                             "background: #b9c9fe;" +
                                                             "font-weight: normal;" +
                                                             "border-top: 4px solid #aabcfe;" +
                                                             "border-bottom: 1px solid #fff;" +
                                                             "color: #039;";

                    mainRow.Cells.Add(courseCodeHeader);
                    mainRow.Cells.Add(courseTitleHeader);
                    mainRow.Cells.Add(weeklyHoursHeader);
                    mainTable.Rows.Add(mainRow);

                    foreach (string courseCode in selectedCourseCodes)
                    {
                        Course courseInstance = Helper.GetCourseByCode(courseCode);
                        if (courseInstance == null)
                        {
                            continue;
                        }

                        TableRow addedRow = new TableRow();
                        TableCell courseCodeCell = new TableCell();
                        courseCodeCell.Text = courseInstance.Code;

                        TableCell courseTitleCell = new TableCell();
                        courseTitleCell.Text = courseInstance.Title;

                        TableCell weeklyHoursCell = new TableCell();
                        weeklyHoursCell.Text = $"{courseInstance.WeeklyHours}";

                        addedRow.Cells.Add(courseCodeCell);
                        addedRow.Cells.Add(courseTitleCell);
                        addedRow.Cells.Add(weeklyHoursCell);
                        mainTable.Rows.Add(addedRow);
                    }

                    mainTable.Attributes["style"] = "font-family: 'Lucida Sans Unicode, Lucida Grande, Sans-Serif';" +
                                                    "font-size: 12px;" +
                                                    "margin: 45px;" +
                                                    "width: 480px;" +
                                                    "text-align: left;" +
                                                    "border-collapse: collapse;";

                    phTable.Controls.Add(mainTable);
                    cbCourseSelection.Visible = false;
                    lblCourseHeader.Text = "has enrolled in the following courses" + "<br/>";
                }
            }
        }
    }
}
