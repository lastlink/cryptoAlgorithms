<?php

namespace App\Http\Controllers\Api;

use Illuminate\Http\Request;
use App\Http\Controllers\Controller;
use Response;

class HashesController extends Controller
{
    public function verify(Request $request){
        $matches = "";
        switch ($request['algorithm']) {
            case 'bcrypt':
                $matches = password_verify($request['password'], $request['hashedPassword']);

                break;
            case 'sha256':
                $hash = hash_pbkdf2("SHA256", $request['password'], $request['salt'], $request['iterations'], 0, true);
                $passwordHash = base64_encode($hash);
                $matches = $passwordHash == $request['hashedPassword'];
                break;
        }
        return Response::json($matches);

    }
    public function store(Request $request)
    {
        $passwordHash = "";
        switch ($request['algorithm']) {
            case 'bcrypt':
                $passwordHash = password_hash($request['password'], PASSWORD_DEFAULT);

                break;
            case 'sha256':
                $hash = hash_pbkdf2("SHA256", $request['password'], $request['salt'], $request['iterations'], 0, true);
                $passwordHash = base64_encode($hash);
                break;
        }
        return Response::json($passwordHash);
    }
}
