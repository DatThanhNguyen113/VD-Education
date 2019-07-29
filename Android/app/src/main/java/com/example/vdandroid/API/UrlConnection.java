package com.example.vdandroid.API;

import android.content.Context;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.io.OutputStreamWriter;
import java.io.UnsupportedEncodingException;
import java.net.HttpURLConnection;
import java.net.ProtocolException;
import java.net.URL;
import java.util.Iterator;
import java.util.Map;

/**
 * Created by Dell on 7/16/2018.
 */

public class UrlConnection {
    private Context context;

    public UrlConnection(Context context) {
        this.context = context;
    }

    public HttpURLConnection ConnectContent(String sUrl) {
        HttpURLConnection connection = null;
        try {
            String token = ((UserInfoBuffer) context.getApplicationContext()).getSession();
            URL url = new URL( "http://103.10.44.30/api" + sUrl );
            connection = (HttpURLConnection) url.openConnection();
            connection.setRequestMethod( "POST" );
            connection.setRequestProperty( "Content-Type", "application/json" );
            connection.setRequestProperty( "Authorization", "Bearer " + token );
            connection.setUseCaches( false );
            connection.setDoInput( true );
            connection.setDoOutput( true );
        } catch (ProtocolException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        }
        return connection;
    }

    public JSONObject getJsonObject() {
        JSONObject jsonObject = new JSONObject();
//        try {
//            jsonObject.put( "CoinName", "BCASH" );
//            jsonObject.put( "Token", "59e3a99297763875dde0a405a7bbbe21" );
//        } catch (JSONException e) {
//            e.printStackTrace();
//        }
        return jsonObject;
    }

    public JSONObject ResponseObject(HttpURLConnection sconnection) {
        BufferedReader reader = null;
        JSONObject parentObject = null;
        try {
            InputStream stream = sconnection.getInputStream();
            reader = new BufferedReader( new InputStreamReader( stream ) );
            StringBuffer buffer = new StringBuffer();
            String line;
            while ((line = reader.readLine()) != null) {
                buffer.append( line );
            }
            String finalJson = buffer.toString();
            parentObject = new JSONObject( finalJson );
        } catch (JSONException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        }
        return parentObject;
    }

    public JSONObject MappingJson(String mUrl, Map<String, String> mMap) {
        HttpURLConnection sconnect = null;
        BufferedReader reader = null;
        JSONObject parentObject = null;
        try {
            UrlConnection connection = new UrlConnection( context );
            sconnect = connection.ConnectContent( mUrl );
            JSONObject jsonObject = connection.getJsonObject();
            JSONArray sArray = new JSONArray();
            JSONObject schildObject = new JSONObject();
            Iterator myIterator = mMap.keySet().iterator();
            while (myIterator.hasNext()) {
                String key = (String) myIterator.next();
                String value = (String) mMap.get( key );
                schildObject.put( key, value );
            }
            sArray.put( schildObject );
            jsonObject.put( "DataParams", sArray );
            OutputStream os = sconnect.getOutputStream();
            BufferedWriter writer = new BufferedWriter(
                    new OutputStreamWriter( os, "UTF-8" ) );
            writer.write( String.valueOf( jsonObject ) );
            writer.flush();
            writer.close();
            os.close();
            sconnect.connect();
            parentObject = connection.ResponseObject( sconnect );
            int ping = sconnect.getResponseCode();
        } catch (UnsupportedEncodingException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        } catch (JSONException e) {
            e.printStackTrace();
        } finally {
            if (sconnect != null) {
                sconnect.disconnect();
            }
            try {
                if (reader != null) {
                    reader.close();
                }
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
        return parentObject;
    }
    public JSONObject MappingJson1(String mUrl, JSONObject jsonObject1) {
        HttpURLConnection sconnect = null;
        BufferedReader reader = null;
        JSONObject parentObject = null;
        try {
            UrlConnection connection = new UrlConnection( context );
            sconnect = connection.ConnectContent( mUrl );
            JSONObject jsonObject = connection.getJsonObject();
            JSONArray sArray = new JSONArray();
//            JSONObject schildObject = new JSONObject();
//            Iterator myIterator = mMap.keySet().iterator();
//            while (myIterator.hasNext()) {
//                String key = (String) myIterator.next();
//                String value = (String) mMap.get( key );
//                schildObject.put( key, value );
//            }
            sArray.put( jsonObject1 );
            jsonObject.put( "DataParams", sArray );
            OutputStream os = sconnect.getOutputStream();
            BufferedWriter writer = new BufferedWriter(
                    new OutputStreamWriter( os, "UTF-8" ) );
            writer.write( String.valueOf( jsonObject ) );
            writer.flush();
            writer.close();
            os.close();
            sconnect.connect();
            parentObject = connection.ResponseObject( sconnect );
            int ping = sconnect.getResponseCode();
        } catch (UnsupportedEncodingException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        } catch (JSONException e) {
            e.printStackTrace();
        } finally {
            if (sconnect != null) {
                sconnect.disconnect();
            }
            try {
                if (reader != null) {
                    reader.close();
                }
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
        return parentObject;
    }
}
