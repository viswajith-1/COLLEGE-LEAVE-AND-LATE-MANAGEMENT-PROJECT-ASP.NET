﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class ParentViewLeave : System.Web.UI.Page
{
    PresentLyClass pl = new PresentLyClass();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblMobile.Text = Session["UserID"].ToString();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Panel2.Visible = true;
        lblStudentID.Text = ddlStudent.SelectedItem.Text;
    }
}