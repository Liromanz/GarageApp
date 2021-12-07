package com.example.test.`interface`

import com.example.test.History
import com.example.test.model.Users
import com.example.test.model.history
import retrofit2.Call
import retrofit2.http.GET

interface API {

    @GET("Users")
    fun user(): Call<ArrayList<Users>>

    @GET("histories")
    fun histories(): Call<ArrayList<history>>

}