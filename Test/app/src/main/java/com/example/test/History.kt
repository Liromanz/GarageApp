package com.example.test

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.text.TextUtils
import android.widget.TextView
import com.example.test.`interface`.API
import com.example.test.model.Users
import com.example.test.model.history
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response
import retrofit2.Retrofit
import retrofit2.converter.gson.GsonConverterFactory

class History : AppCompatActivity() {

    private var id = 0

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_history)

        id = intent.getIntExtra("id", 0)

        var history = findViewById<TextView>(R.id.history)

        var retrofit = Retrofit.Builder().baseUrl("https://wsrexampleapi.azurewebsites.net/api/")
            .addConverterFactory(GsonConverterFactory.create()).build()
        retrofit.create(API::class.java)
            .histories()
            .enqueue(object : Callback<ArrayList<history>> {
                override fun onResponse(
                    call: Call<ArrayList<history>>,
                    response: Response<ArrayList<history>>
                ) {
                    val lines: MutableList<String?> = ArrayList()
                    for (i in 0 until response.body()!!.size) {
                        if (id == response.body()!!.get(i).idUser) {
                            lines.add(response.body()!!.get(i).datePass)
                        }
                    }
                    history.text = TextUtils.join("\n", lines)
                }

                override fun onFailure(call: Call<ArrayList<history>>, t: Throwable) {

                }
            })
    }
}