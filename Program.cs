using System;
using System.Collections.Generic;


public class Mahasiswa
{
    private string nim;
    private string nama;
    private string jurusan;

    public Mahasiswa(string _nim, string _nama, string _jurusan)
    {
        nim = _nim;
        nama = _nama;
        jurusan = _jurusan;
    }

    public string GetNim()
    {
        return nim;
    }
    public string GetNama()
    {
        return nama;
    }
    public string GetJurusan()
    {
        return jurusan;
    }
    public void SetNama(string _nama)
    {
        nama = _nama;
    }
    public void SetJurusan(string _jurusan)
    {
        jurusan = _jurusan;
    }

    public override string ToString()
    {
        return $"NIM: {nim}, Nama: {nama}, Jurusan: {jurusan}";
    }
}


public class ManajemenMahasiswa
{
    private List<Mahasiswa> daftarMahasiswa = new List<Mahasiswa>();

    public void TambahMahasiswa(Mahasiswa mhs)
    {
        if (daftarMahasiswa.Exists(m => m.GetNim() == mhs.GetNim()))
        {
            Console.WriteLine("NIM sudah ada. Data mahasiswa tidak dapat ditambahkan.");
        }
        else
        {
            daftarMahasiswa.Add(mhs);
            Console.WriteLine("Data mahasiswa berhasil ditambahkan.");
        }
    }

    public void LihatMahasiswa()
    {
        if (daftarMahasiswa.Count == 0)
        {
            Console.WriteLine("Belum ada data mahasiswa.");
            return;
        }

        foreach (var mhs in daftarMahasiswa)
        {
            Console.WriteLine(mhs.ToString());
        }
    }

    public void UpdateMahasiswa(string nimCari, string namaBaru, string jurusanBaru)
    {
        var mhs = daftarMahasiswa.Find(m => m.GetNim() == nimCari);
        if (mhs != null)
        {
            mhs.SetNama(namaBaru);
            mhs.SetJurusan(jurusanBaru);
            Console.WriteLine("Data mahasiswa berhasil diupdate.");
        }
        else
        {
            Console.WriteLine("NIM tidak ditemukan.");
        }
    }

    public void HapusMahasiswa(string nimCari)
    {
        var mhs = daftarMahasiswa.Find(m => m.GetNim() == nimCari);
        if (mhs != null)
        {
            daftarMahasiswa.Remove(mhs);
            Console.WriteLine("Data mahasiswa berhasil dihapus.");
        }
        else
        {
            Console.WriteLine("NIM tidak ditemukan.");
        }
    }
}


class Program
{
    static void Main(string[] args)
    {
        ManajemenMahasiswa manajemen = new ManajemenMahasiswa();
        int pilihan;

        do
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Tambah Mahasiswa");
            Console.WriteLine("2. Lihat Mahasiswa");
            Console.WriteLine("3. Update Mahasiswa");
            Console.WriteLine("4. Hapus Mahasiswa");
            Console.WriteLine("5. Keluar");
            Console.Write("Pilih menu: ");
            bool validInput = int.TryParse(Console.ReadLine(), out pilihan);

            if (!validInput)
            {
                Console.WriteLine("Input tidak valid. Silakan masukkan angka antara 1 sampai 5.");
                continue;
            }

            switch (pilihan)
            {
                case 1:
                    Console.Write("Masukkan NIM: ");
                    string nim = Console.ReadLine();
                    Console.Write("Masukkan Nama: ");
                    string nama = Console.ReadLine();
                    Console.Write("Masukkan Jurusan: ");
                    string jurusan = Console.ReadLine();
                    manajemen.TambahMahasiswa(new Mahasiswa(nim, nama, jurusan));
                    break;

                case 2:
                    manajemen.LihatMahasiswa();
                    break;

                case 3:
                    Console.Write("Masukkan NIM yang ingin diupdate: ");
                    string nimUpdate = Console.ReadLine();
                    Console.Write("Masukkan Nama baru: ");
                    string namaUpdate = Console.ReadLine();
                    Console.Write("Masukkan Jurusan baru: ");
                    string jurusanUpdate = Console.ReadLine();
                    manajemen.UpdateMahasiswa(nimUpdate, namaUpdate, jurusanUpdate);
                    break;

                case 4:
                    Console.Write("Masukkan NIM yang ingin dihapus: ");
                    string nimHapus = Console.ReadLine();
                    manajemen.HapusMahasiswa(nimHapus);
                    break;

                case 5:
                    Console.WriteLine("Keluar dari program.");
                    break;

                default:
                    Console.WriteLine("Pilihan tidak valid. Silakan coba lagi.");
                    break;
            }
        } while (pilihan != 5);
    }
}

