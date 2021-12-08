using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace P6_1_1204036
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //perintah SQL untuk menyimpan data inputan user ke basisdata 
            string myCmd = "INSERT INTO msprodi VALUES('"
            + id_prodi.Text + "','" 
            + nama_prodi.Text + "','"
             + singkatan.Text + "','" 
            + ka_prodi.Text + "','" 
             + sek_prodi.Text + "')";

            //memanggil method UpdateDB dengan set parameter myCmd UpdateDB (myCmd);
            UpdateDB(myCmd);
        }
        private void UpdateDB(string cmd)
        {
            try
            {
                // connection string digunakan untuk koneksi ke basisdata PRG2_XXXXXXX.
                //perhatikan data source berisi "." menunjukkan komputer localhost, 
                //pada kenyataannya Anda akan menggantinya dengan alamat IP komputer server basisdata
                //string connectionString = "Data Source=P6_1204036;Initial Catalog=P6_1204036;Integrated Security=True";

                //membuat object dengan nama myConnection, inisialisasi dengan connection string
                SqlConnection myConnection = new SqlConnection(@"Data Source=DESKTOP-NAWAF\P6_1204036; Initial Catalog = P6_1204036; Integrated Security = True");

                //mmebuka koneksi, menggunakan object myConnection 
                myConnection.Open();

                //membuat object dengan nama my Command, inisialisasi dari class SqlCommand
                SqlCommand myCommand = new SqlCommand();

                //menetapkan koneksi basisdata yang digunakan, yaitu object myConnection
                myCommand.Connection = myConnection;

                //mengatur query yang digunakan, diambil dari parameter cmd 
                myCommand.CommandText = cmd;

                //eksekusi myCommand yang diambil dari parameter cmd 
                myCommand.ExecuteNonQuery();

                //menampilkan pesan jika eksekusi berhasil
                MessageBox.Show("Basisdata berhasil diperbarui", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //penanganan apabila terjadi error pada saat try, exception diset dalam variabel ex 
                catch (Exception ex)
            {
                //menampilkan pesan kesalahan 
                MessageBox.Show(ex.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //mengosonkan isian dalam TextBox 
            id_prodi.Text = "";
            nama_prodi.Text = "";
            singkatan.Text = "";
            ka_prodi.Text = "";
            sek_prodi.Text = "";
        }
    }


}
