package com.example.vdandroid;

import android.os.Bundle;
import android.support.design.widget.TabLayout;
import android.support.v4.app.Fragment;
import android.support.v4.view.ViewPager;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.Spinner;
import android.widget.TextView;

import com.example.vdandroid.Adapter.LessonAdapter;
import com.example.vdandroid.Adapter.PageAdapter;
import com.example.vdandroid.Adapter.TimeTableAdapter;
import com.example.vdandroid.Model.FinishDateModel;
import com.example.vdandroid.Model.LessonModel;
import com.example.vdandroid.Model.StartDateModel;
import com.example.vdandroid.Model.TimeTableModel;
import com.example.vdandroid.Presenter.TimeTableTask;
import com.example.vdandroid.View.Interface.IViewTimeTable;

import java.lang.reflect.Field;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.List;

public class FragmentLesson extends Fragment {
    private ListView listViewLesson;
    private Spinner spinnerWeek;
    public static List<TimeTableModel> timeTableList;
    static List<StartDateModel> startDateModelList;
    static List<FinishDateModel> finishDateModelList;
    TimeTableAdapter adapter;


    public static FragmentLesson newInstance() {
        FragmentLesson fragmentLesson = new FragmentLesson();
        return fragmentLesson;
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate( savedInstanceState );
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        View view = inflater.inflate( R.layout.fragment_lesson, container, false );
        onInit( view );
        onGetTimeTable();
//        onEvent();
        onSpinnerSelect();
        return view;
    }

    private void onInit(View view) {
        listViewLesson = view.findViewById( R.id.listViewLesson );
        spinnerWeek = view.findViewById( R.id.spinnerWeek );
    }

    private void onSpinnerSelect(){
        spinnerWeek.setOnItemSelectedListener( new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> adapterView, View view, int i, long l) {
                onEvent();
            }

            @Override
            public void onNothingSelected(AdapterView<?> adapterView) {

            }
        } );
    }

    private void onEvent(){
        String date = spinnerWeek.getSelectedItem().toString();
        String[] mWeek = date.split( "\\(" );
        String week = mWeek[0];
        String start_date = "", finish_date = "";
        for(int i = 0; i < startDateModelList.size(); i++){
            if(week.equals( startDateModelList.get( i ).getWeek() )){
                start_date = startDateModelList.get( i ).getStartDate();
            }
        }
        for(int i = 0; i < finishDateModelList.size(); i++){
            if(week.equals( finishDateModelList.get( i ).getWeek() )){
                finish_date = finishDateModelList.get( i ).getFinishDate();
            }
        }
        SimpleDateFormat sdf = new SimpleDateFormat("dd/MM/yyyy");
        ArrayList<Object> list = new ArrayList<>();
        for(int i = 0; i < timeTableList.size(); i++){
            try {
                Date date_start = sdf.parse( start_date );
                Date date_finish = sdf.parse( finish_date );
                Date date_lesson = sdf.parse( onSetTitleHeader(timeTableList.get( i ).getDate()) );
                if((date_lesson.compareTo( date_start ) >= 0) && (date_lesson.compareTo( date_finish ) <= 0)){
                    String date_1 = timeTableList.get( i ).getDate();
                    String title = timeTableList.get( i ).getDay() + ", " + onSetTitleHeader( date_1 );
                    if (!list.contains( title )) {
                        list.add( title );
                        list.add( timeTableList.get( i ) );
                    } else {
                        list.add( timeTableList.get( i ) );
                    }
                }
            } catch (ParseException e) {
                e.printStackTrace();
            }
        }
        listViewLesson.setAdapter( new TimeTableAdapter( getContext(), list ) );

    }

    private void onGetTimeTable() {
        new TimeTableTask( getContext(), new IViewTimeTable() {
            @Override
            public void onGetSuccess() {
                ArrayList<Object> list = new ArrayList<>();
                for (int i = 0; i < timeTableList.size(); i++) {
                    String date = timeTableList.get( i ).getDate();
                    String title = timeTableList.get( i ).getDay() + ", " + onSetTitleHeader( date );
                    if (!list.contains( title )) {
                        list.add( title );
                        list.add( timeTableList.get( i ) );
                    } else {
                        list.add( timeTableList.get( i ) );
                    }
                }
                onGetWeek();
            }

            @Override
            public void onGetFail() {

            }
        } ).execute();
    }

    private String onSetTitleHeader(String header) {
        String[] mdate = header.split( "-" );
        String nam = mdate[0];
        String thang = mdate[1];
        String mdate2 = mdate[2].substring( 0, 2 );
        String ngay = mdate2;
        String title = (ngay + "/" + thang + "/" + nam);
        return title;
    }

    private void onGetWeek() {
        int first_week = timeTableList.get( 0 ).getFrom_week();
        String first_date = timeTableList.get( 0 ).getFrom_date();
        int end_week = timeTableList.get( 0 ).getTo_week();
        for (int i = 0; i < timeTableList.size(); i++) {
            int from_week = timeTableList.get( i ).getFrom_week();
            int to_week = timeTableList.get( i ).getTo_week();
            String from_date = timeTableList.get( i ).getFrom_date();
            if (from_week < first_week) {
                first_week = from_week;
                first_date = from_date;
            }
            if (to_week > end_week) {
                end_week = to_week;
            }
        }
        List<String> list = new ArrayList<>();
        startDateModelList = new ArrayList<>();
        finishDateModelList = new ArrayList<>();
        for (int i = first_week; i <= end_week; i++) {
            String[] mDate = onCalculatorDate( first_date );
            list.add( "Tuần " + String.valueOf( i ) + "( " + mDate[0] + " - " + mDate[1] + " )" );
            first_date = mDate[2];
            StartDateModel startDateModel = new StartDateModel();
            FinishDateModel finishDateModel = new FinishDateModel();
            //
            startDateModel.setWeek( "Tuần " + i );
            startDateModel.setStartDate( mDate[0] );
            startDateModelList.add( startDateModel );
            //
            finishDateModel.setWeek( "Tuần " + i );
            finishDateModel.setFinishDate( mDate[1] );
            finishDateModelList.add( finishDateModel );
        }
        onLimitHeightSpinner();
        ArrayAdapter<String> dataAdapter = new ArrayAdapter<String>( getContext(), android.R.layout.simple_spinner_item, list );
        dataAdapter.setDropDownViewResource( android.R.layout.simple_spinner_dropdown_item );
        spinnerWeek.setAdapter( dataAdapter );
        onEvent();
    }

    private void onLimitHeightSpinner(){
        try {
            Field popup = Spinner.class.getDeclaredField("mPopup");
            popup.setAccessible(true);

            // Get private mPopup member variable and try cast to ListPopupWindow
            android.widget.ListPopupWindow popupWindow = (android.widget.ListPopupWindow) popup.get(spinnerWeek);

            // Set popupWindow height to 500px
            popupWindow.setHeight(400);
        }
        catch (NoClassDefFoundError | ClassCastException | NoSuchFieldException | IllegalAccessException e) {
            // silently fail...
        }
    }

    private String[] onCalculatorDate(String header) {
        String[] mDate = new String[3];
        SimpleDateFormat sdf = new SimpleDateFormat( "dd/MM/yyyy" );
        if (header.contains( "/" )) {
            Calendar calendar = Calendar.getInstance();
            try {
                calendar.setTime( sdf.parse( header ) );
            } catch (ParseException e) {
                e.printStackTrace();
            }
            calendar.add( Calendar.DAY_OF_MONTH, 6 );
            String end_of_week = sdf.format( calendar.getTime() );
            mDate[0] = header;
            mDate[1] = end_of_week;
            calendar.clear();
            try {
                calendar.setTime( sdf.parse( header ) );
            } catch (ParseException e) {
                e.printStackTrace();
            }
            calendar.add( Calendar.DAY_OF_MONTH, 7 );
            String new_start_date_of_week = sdf.format( calendar.getTime() );
            mDate[2] = new_start_date_of_week;
            return mDate;
        } else {
            String[] mdate = header.split( "-" );
            String nam = mdate[0];
            String thang = mdate[1];
            String mdate2 = mdate[2].substring( 0, 2 );
            String ngay = mdate2;
            String title = (ngay + "/" + thang + "/" + nam);
            Calendar calendar = Calendar.getInstance();
            calendar.set( Integer.parseInt( nam ), Integer.parseInt( thang ), Integer.parseInt( ngay ) );
            calendar.add( Calendar.DATE, 6 );
            Date date = calendar.getTime();
            Log.e( "NEW", date.toString() );
            Log.d( "NEW DATE END", calendar.get( Calendar.DATE ) + "/" + calendar.get( Calendar.MONTH ) + "/" + calendar.get( Calendar.YEAR ) );
            String date_end_of_week = calendar.get( Calendar.DATE ) + "/" + calendar.get( Calendar.MONTH ) + "/" + calendar.get( Calendar.YEAR );
            mDate[0] = title;
            mDate[1] = date_end_of_week;
            calendar.clear();
            calendar.set( Integer.parseInt( nam ), Integer.parseInt( thang ), Integer.parseInt( ngay ) );
            calendar.add( Calendar.DATE, 7 );
            String new_start_date_of_week = calendar.get( Calendar.DATE ) + "/" + calendar.get( Calendar.MONTH ) + "/" + calendar.get( Calendar.YEAR );
            mDate[2] = new_start_date_of_week;
            return mDate;
        }
    }
}