﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class AdminHome : System.Web.UI.Page
{
    PresentLyClass pl = new PresentLyClass();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblUserID.Text = Session["UserID"].ToString();
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("ADMStudent.aspx");
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("TeacherRegistration.aspx");
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        Response.Redirect("ParentRegistration.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (txtNewPWd.Text == txtCnfPwd.Text)
        {
            string qry1 = "select * from LoginTBL where UserID='" + lblUserID.Text + "'";
            dt = pl.dbSelect(qry1);
            string CrPwd = dt.Rows[0]["Password"].ToString();

            if (CrPwd == txtCrPwd.Text)
            {
                string qry2 = "update LoginTBL set Password='" + txtNewPWd.Text + "' where UserID='" + lblUserID.Text + "'";
                pl.dbExecute(qry2);

                Response.Write("<script>alert('Password Changed...Login Agin Now.....')</script>");
                Response.Write("<script>window.location.href='Login.aspx';</script>");
            }
            else
            {
                Response.Write("<script>alert('Current Password Mismatch')</script>");
                Response.Write("<script>window.location.href='AdminChangePassword.aspx';</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('Password Mismatch')</script>");
            Response.Write("<script>window.location.href='AdminChangePassword.aspx';</script>");
        }
    }
}