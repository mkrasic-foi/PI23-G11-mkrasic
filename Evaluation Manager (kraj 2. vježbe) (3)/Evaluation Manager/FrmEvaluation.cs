﻿using Evaluation_Manager.Models;
using Evaluation_Manager.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evaluation_Manager {
    public partial class FrmEvaluation : Form {

        private Student student;
        private Student selectedStudent;

        public FrmEvaluation(Student selectedStudent)
        {
            InitializeComponent();

            student = selectedStudent;
            //this.selectedStudent = selectedStudent;
        }

        public FrmEvaluation(Student selectedStudent, Student student)
        {
            InitializeComponent();
            this.selectedStudent = selectedStudent;
            //student = selectedStudent;

        }

        private void FrmEvaluation_Load(object sender, EventArgs e)
        {
            SetFormText();
            var activities = ActivityRepositorpy.GetActivities();
            cboActivities.DataSource = activities;
        }
        private void SetFormText()
        {
            Text = student.FirstName + " " + student.LastName;
        }

        private void cboActivities_SelectedIndexChanged(object sender, EventArgs e)
        {
            var currentActivity = cboActivities.SelectedItem as Activity;
            txtActivityDescription.Text = currentActivity.Description;
            txtMinForGrade.Text = currentActivity.MinPointsForGrade + "/" +
           currentActivity.MaxPoints;
            txtMinForSignature.Text = currentActivity.MinPointsForSignature + "/" +
           currentActivity.MaxPoints;

            numPoints.Minimum = 0;
            numPoints.Maximum = currentActivity.MaxPoints;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
