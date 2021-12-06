package com.example.test

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.view.View
import android.widget.Toast
import java.io.*
import android.os.Environment
import android.util.Log
import java.lang.StringBuilder


class MainActivity : AppCompatActivity() {

    val LOG_TAG = "myLogs"

    val FILENAME = "file"

    val DIR_SD = "MyFiles"
    val FILENAME_SD = ""


    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)
    }

    fun Test(view: View) {
        var myFile = Intent (Intent.ACTION_GET_CONTENT)
        myFile.type = "*/*"

        val mimeTypes = arrayOf("text/plain")

        myFile.putExtra(Intent.EXTRA_MIME_TYPES,mimeTypes);
        startActivityForResult(myFile,10)
    }

    override fun onActivityResult(requestCode: Int, resultCode: Int, data: Intent?) {
        super.onActivityResult(requestCode, resultCode, data)

        if(requestCode == 10){
            var path = data!!.data!!.path

            val myFile = File(Environment.getExternalStorageDirectory().toString() + "/" + path)
            try {
                val inputStream = FileInputStream(myFile)
                /*
             * Буфферезируем данные из выходного потока файла
             */
                val bufferedReader = BufferedReader(InputStreamReader(inputStream))
                /*
             * Класс для создания строк из последовательностей символов
             */
                val stringBuilder = StringBuilder()
                var line: String?
                try {
                    /*
                 * Производим построчное считывание данных из файла в конструктор строки,
                 * Псоле того, как данные закончились, производим вывод текста в TextView
                 */
                    while (bufferedReader.readLine().also { line = it } != null) {
                        stringBuilder.append(line)
                    }
                    Toast.makeText(this, stringBuilder, Toast.LENGTH_SHORT).show()
                } catch (e: IOException) {
                    e.printStackTrace()
                }
            } catch (e: FileNotFoundException) {
                e.printStackTrace()
            }

        }

    }
}
