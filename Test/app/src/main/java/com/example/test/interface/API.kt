package com.example.test.`interface`

import com.example.test.model.Users
import retrofit2.Call
import retrofit2.http.GET

interface API {

    @GET("Users")
    fun user(): Call<ArrayList<Users>>

}