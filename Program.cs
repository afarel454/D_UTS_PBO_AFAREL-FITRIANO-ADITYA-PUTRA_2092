// Book.cs
public class Book
{
    public int ID { get; set; }
    public string Judul { get; set; }
    public string Penulis { get; set; }
    public int TahunTerbit { get; set; }
    public virtual string Status { get; set; }

    public Book(int id, string judul, string penulis, int tahunTerbit)
    {
        ID = id;
        Judul = judul;
        Penulis = penulis;
        TahunTerbit = tahunTerbit;
        Status = "Tersedia";
    }

    public virtual void TampilkanInfo()
    {
        Console.WriteLine($"ID: {ID}, Judul: {Judul}, Penulis: {Penulis}, Tahun: {TahunTerbit}, Status: {Status}");
    }
}

// BorrowableBook.cs (inheritance dari Book)
public class BorrowableBook : Book
{
    public BorrowableBook(int id, string judul, string penulis, int tahunTerbit)
        : base(id, judul, penulis, tahunTerbit)
    {
    }

    public void Pinjam()
    {
        Status = "Dipinjam";
    }

    public void Kembalikan()
    {
        Status = "Tersedia";
    }
}

// Library.cs
using System;
using System.Collections.Generic;
using System.Linq;

public class Library
{
    public string Nama { get; set; }
    public string Alamat { get; set; }
    private List<BorrowableBook> koleksiBuku;

    public Library(string nama, string alamat)
    {
        Nama = nama;
        Alamat = alamat;
        koleksiBuku = new List<BorrowableBook>();
    }

    public void TambahBuku(BorrowableBook buku)
    {
        koleksiBuku.Add(buku);
        Console.WriteLine("Buku berhasil ditambahkan.");
    }

    public void TampilkanSemuaBuku()
    {
        foreach (var buku in koleksiBuku)
        {
            buku.TampilkanInfo();
        }
    }

    public BorrowableBook CariBuku(int id)
    {
        return koleksiBuku.FirstOrDefault(b => b.ID == id);
    }

    public void UpdateBuku(int id, string judul, string penulis, int tahun)
    {
        var buku = CariBuku(id);
        if (buku != null)
        {
            buku.Judul = judul;
            buku.Penulis = penulis;
            buku.TahunTerbit = tahun;
            Console.WriteLine("Buku berhasil diupdate.");
        }
        else
        {
            Console.WriteLine("Buku tidak ditemukan.");
        }
    }

    public void HapusBuku(int id)
    {
        var buku = CariBuku(id);
        if (buku != null)
        {
            koleksiBuku.Remove(buku);
            Console.WriteLine("Buku berhasil dihapus.");
        }
        else
        {
            Console.WriteLine("Buku tidak ditemukan.");
        }
    }
}


