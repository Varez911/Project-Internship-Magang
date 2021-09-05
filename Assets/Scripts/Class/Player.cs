using UnityEngine;
namespace UnityTemplateProjects.Class
{
    public class Player
    {
        private string Nama;
        private string Alamat;
        private int noHp;
        private string Email;

        public string Nama1
        {
            get => Nama;
            set => Nama = value;
        }

        public string Alamat1
        {
            get => Alamat;
            set => Alamat = value;
        }

        public int NoHp
        {
            get => noHp;
            set => noHp = value;
        }

        public string Email1
        {
            get => Email;
            set => Email = value;
        }
    }
}