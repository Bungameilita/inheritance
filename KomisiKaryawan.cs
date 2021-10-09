using System;

public class KomisiKaryawan 
{
  public string NamaDepan { get; }
  public string NamaBelakang { get; }
  public string NomorKTP { get; }
  private decimal penjualanKotor; // gross weekly sales
  private decimal tingkatKomisi; // commission percentage

  public KomisiKaryawan(string namaDepan, string namaBelakang,string nomorKTP, decimal penjualanKotor,
  decimal tingkatKomisi)
  {
    NamaDepan = namaDepan;
    NamaBelakang = namaBelakang;
    NomorKTP = nomorKTP;
    PenjualanKotor = penjualanKotor; // validates gross sales
    TingkatKomisi = tingkatKomisi; // validates commission rate
  }
  public decimal PenjualanKotor
  {
    get
    {
      return penjualanKotor;
    }
    set
    {
      if (value < 0) // validation
      {
        throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(PenjualanKotor)} must be >= 0");
      }
      penjualanKotor = value;
    }
  }
 
  public decimal TingkatKomisi
  {
    get
    {
      return tingkatKomisi ;
    }
    set
    {
      if (value <= 0 || value >= 1) // validation
      {
        throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(TingkatKomisi)} must be > 0 and < 1");
      }
      tingkatKomisi = value;
    }
  }
  
  public virtual decimal Earnings() => TingkatKomisi * PenjualanKotor;
  public override string ToString() =>
  $"Komisi Karyawan: {NamaDepan} {NamaBelakang}\n" + $"Noor KTP: {NomorKTP}\n" + $"Penjualan Kotor: { PenjualanKotor:C}\n" + $"Tingkat Komisi: {TingkatKomisi :F2}";
 
}

public class KaryawanDasarTambahKomisi : KomisiKaryawan
{
  private decimal gajiPokok; // base salary per week

  // six-parameter constructor
  public KaryawanDasarTambahKomisi(string namaDepan, string namaBelakang,string nomorKTP, decimal penjualanKotor,
  decimal tingkatKomisi, decimal gajiPokok)
  : base(namaDepan, namaBelakang, nomorKTP,
  penjualanKotor, tingkatKomisi)
  {
    GajiPokok = gajiPokok; // validates base salary
  }

  // property that gets and sets
  // BasePlusCommissionEmployee's base salary
  public decimal GajiPokok
  {
    get
    {
      return gajiPokok;
    }
    set
    {
      if (value < 0) // validation
      {
        throw new ArgumentOutOfRangeException(nameof(value),
        value, $"{nameof(GajiPokok)} must be >= 0");
      }

     gajiPokok = value;
    }
  }

  public override decimal Earnings() => GajiPokok + base.Earnings();
  public override string ToString() => $"gaji pokok {base.ToString()}\ngaji pokok {GajiPokok:C}";
}

