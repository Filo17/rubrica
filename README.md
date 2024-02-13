# Rubrica
Esercizio con esempio di doppia grid per visualizzare una relazione uno a molti, allo scopo di simulare una rubrica telefonica
## Descrizione del progretto
Realizzazione di un programma in WBF che simula una rubrica. <br>
**Ad esempio:**
Ci sarà una lista di persone su una parte dello schermo, se una persona viene selezionata, appariranno tutti i suoi dettagli in un'altra parte dello schermo


## Come funziona?
  
<details>
<summary>Creare la lista di persone da un file .csv </summary>

```c#
    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        try
        {   //leggi persone
            StreamReader fin = new StreamReader("Persone.csv");
            fin.ReadLine();
    
            Persone = new List<Persona>();
            while (!fin.EndOfStream)
            {
                //semplifica in persone.Add(new Persona(fin.ReadLine()));
                string riga = fin.ReadLine();
                Persona p = new Persona(riga);
                Persone.Add(p);
            }
    
            dgPersone.ItemsSource = Persone;
            fin.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
```

Questo codice serve a prendere elementi da un file chiamato "Persone.csv" leggendo ogni riga con lo StreamReader e assegnare il suo valore a una persona, che viene aggiunta a una lista che viene usata come ItemsSource di un dataGrid
</details>

