package com.example.test

import android.content.Context
import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.util.Log
import android.view.View
import android.widget.EditText
import android.widget.TextView
import com.example.test.`interface`.API
import com.example.test.model.Users
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response
import retrofit2.Retrofit
import retrofit2.converter.gson.GsonConverterFactory

import android.content.SharedPreferences

import android.app.Activity




class SingIn : AppCompatActivity() {

    private  var login: TextView? = null
    private  var password: TextView? = null

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_sing_in)

        login = findViewById<EditText>(R.id.Login)
        password = findViewById<EditText>(R.id.Password)
    }

    fun Input(view: View) {


        var retrofit = Retrofit.Builder().baseUrl("https://wsrexampleapi.azurewebsites.net/api/")
            .addConverterFactory(GsonConverterFactory.create()).build()
        retrofit.create(API::class.java)
            .user()
            .enqueue(object : Callback<ArrayList<Users>> {
                override fun onResponse(
                    call: Call<ArrayList<Users>>,
                    response: Response<ArrayList<Users>>
                ) {

                    for (i in 0 until response.body()!!.size)
                    {
                        if(login!!.text.toString() == response.body()!!.get(i).login  && password!!.text.toString() == response.body()!!.get(i).password)
                        {
                            val intent = Intent(this@SingIn,MainActivity::class.java)
                            intent.flags = Intent.FLAG_ACTIVITY_CLEAR_TASK.or(Intent.FLAG_ACTIVITY_NEW_TASK)
                            intent.putExtra("id", response.body()!!.get(i).id)

                            startActivity(intent)
                            break
                        }
                    }
                }

                override fun onFailure(call: Call<ArrayList<Users>>, t: Throwable) {

                }
            })
    }
}