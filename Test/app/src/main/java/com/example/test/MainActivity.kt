package com.example.test

import android.content.Context
import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.view.View
import android.widget.Toast
import java.io.*
import android.os.Environment
import android.text.TextUtils
import android.util.Log
import android.widget.TextView
import java.lang.Exception
import java.lang.StringBuilder
import android.widget.EditText
import com.example.test.`interface`.API
import com.example.test.model.Users
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response
import retrofit2.Retrofit
import retrofit2.converter.gson.GsonConverterFactory


class MainActivity : AppCompatActivity() {

    val LOG_TAG = "myLogs"
    val FILENAME = "file"
    val DIR_SD = "MyFiles"
    val FILENAME_SD = ""

    private  var contentUnit:TextView? = null
    private  var positionUnit:TextView? = null

    private var id = 0
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        contentUnit = findViewById<TextView>(R.id.contentUnit)
        positionUnit = findViewById<TextView>(R.id.positionUnit)


        id =  intent.getIntExtra("id",0);
        Toast.makeText(this, id.toString(), Toast.LENGTH_SHORT).show()
    }

    fun UnitContent(view: View) {

        var myFile = Intent(Intent.ACTION_GET_CONTENT)
        myFile.type = "*/*"
        val mimeTypes = arrayOf("text/plain")
        myFile.putExtra(Intent.EXTRA_MIME_TYPES, mimeTypes);
        startActivityForResult(myFile, 10)
    }
    fun UnitPosition(view: View) {
        var myFile = Intent(Intent.ACTION_GET_CONTENT)
        myFile.type = "*/*"
        val mimeTypes = arrayOf("text/plain")
        myFile.putExtra(Intent.EXTRA_MIME_TYPES, mimeTypes);
        startActivityForResult(myFile, 20)
    }
    override fun onActivityResult(requestCode: Int, resultCode: Int, data: Intent?) {
        super.onActivityResult(requestCode, resultCode, data)
        var path = data!!.data!!
        if (requestCode == 10) {
            try {
                val inputStream = contentResolver.openInputStream(path)
                val lines: MutableList<String?> = ArrayList()
                val reader = BufferedReader(InputStreamReader(inputStream))
                var line = reader.readLine()
                while (line != null) {
                    lines.add(line)
                    line = reader.readLine()
                }
                contentUnit!!.text =   TextUtils.join("\n", lines)
                Toast.makeText(
                    this,
                    TextUtils.join("\n", lines),
                    Toast.LENGTH_SHORT
                ).show()
            } catch (e: Exception) {
                e.printStackTrace()
            }

        }

        if(requestCode == 20)
        {
            try {
                val inputStream = contentResolver.openInputStream(path)
                val lines: MutableList<String?> = ArrayList()
                val reader = BufferedReader(InputStreamReader(inputStream))
                var line = reader.readLine()
                while (line != null) {
                    lines.add(line)
                    line = reader.readLine()
                }
                positionUnit!!.text =   TextUtils.join("\n", lines)
                Toast.makeText(
                    this,
                    TextUtils.join("\n", lines),
                    Toast.LENGTH_SHORT
                ).show()
            } catch (e: Exception) {
                e.printStackTrace()
            }
        }

    }

    fun History(view: View) {
        val intent = Intent(this,History::class.java)
        intent.putExtra("id",id)
        startActivity(intent)
    }

}
