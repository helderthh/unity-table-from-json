using TMPro;
using UnityEngine;
using System.Collections.Generic;


namespace TableFromJSON
{
    using GenDataType = DataHolder.GenDataType;

    public class TableController : MonoBehaviour
    {
        public bool ShouldUseDefaultData = true;
        public string FileName = "JsonChallenge.json";

        [Header("UI")]
        public RectTransform Table;
        public TextMeshProUGUI Title;

        [Header("Prefabs")]
        public Transform HeaderCellPrefab;
        public Transform CellPrefab;
        public Transform RowPrefab;


        void Start()
        {
            LoadData();
        }

        /// <summary>
        /// Read the data from FileName and fill the table on the UI.
        /// </summary>
        public void LoadData()
        {
            Read();
            FillUI();
        }

        void Read()
        {
            if (ShouldUseDefaultData)
                UseDefaultData();
            else
                DataHolder.ReadFromFile(FileName);
        }

        void FillUI()
        {
            Clear();

            // Fill title and create a row for headers
            Title.text = DataHolder.Title;

            var HeaderRow = Instantiate(RowPrefab, Table);

            // fill headers
            foreach (var headerName in DataHolder.ColumnHeaders)
            {
                var cell = Instantiate(HeaderCellPrefab, HeaderRow);
                var textMeshPro = cell.GetComponent<TextMeshProUGUI>();
                textMeshPro.text = headerName;
            }

            // create and fill the data rows
            foreach (var item in DataHolder.Data)
            {
                var row = Instantiate(RowPrefab, Table);
                foreach (var entry in item)
                {
                    var cell = Instantiate(CellPrefab, row);
                    var textMeshPro = cell.GetComponent<TextMeshProUGUI>();
                    textMeshPro.text = entry.Value;
                }
            }
        }

        void Clear()
        {
            foreach (Transform child in Table)
                Destroy(child.gameObject);
        }

        void UseDefaultData()
        {
            DataHolder.Title = "Default Data";
            DataHolder.ColumnHeaders = new List<string>() { "Name", "Age" };

            DataHolder.Data = new List<GenDataType>() {
                new GenDataType()
                {
                    {"Name", "Adriana"},
                    {"Age", "31"},
                },
                new GenDataType()
                {
                    {"Name", "Helderth"},
                    {"Age", "27"},
                },
                new GenDataType()
                {
                    {"Name", "Pablo"},
                    {"Age", "28"},
                },
            };
        }
    }
}