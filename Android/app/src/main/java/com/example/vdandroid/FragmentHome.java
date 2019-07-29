package com.example.vdandroid;

import android.content.Intent;
import android.os.Bundle;
import android.support.annotation.NonNull;
import android.support.design.widget.BottomNavigationView;
import android.support.v4.app.Fragment;
import android.support.v7.widget.CardView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.example.vdandroid.API.UserInfoBuffer;
import com.example.vdandroid.View.RegisterSubject.RegisterSubjectActivity;
import com.example.vdandroid.View.StudentActivity;


/**
 * A simple {@link Fragment} subclass.
 * Use the {@link FragmentHome#newInstance} factory method to
 * create an instance of this fragment.
 */
public class FragmentHome extends Fragment {

    private CardView cardView_Lesson;
    private CardView cardView_RegisterSubjects;
    private CardView cardView_File;
    private CardView cardView_Notification;

    public FragmentHome() {
        // Required empty public constructor
    }

    /**
     * Use this factory method to create a new instance of
     * this fragment
     * @return A new instance of fragment FirstFragment.
     */
    public static FragmentHome newInstance() {
        FragmentHome fragment = new FragmentHome();
        return fragment;
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }

    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        View view =  inflater.inflate(R.layout.fragment_home, container, false);
        onInit( view );
        onEvent();
        return view;
    }

    private void onInit(View view){
        cardView_RegisterSubjects = view.findViewById( R.id.cardView_RegisterSubjects );
        cardView_Lesson = view.findViewById( R.id.cardView_Lesson );
        cardView_File = view.findViewById( R.id.cardView_File );
        cardView_Notification = view.findViewById( R.id.cardView_Notification );
    }

    private void onEvent(){
        String role_name = ((UserInfoBuffer) getActivity().getApplicationContext()).getRole_Name();
        cardView_Lesson.setOnClickListener( new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                ((BottomNavigationView)getActivity().findViewById(R.id.bottom_navigation)).setSelectedItemId(R.id.action_lesson);
            }
        } );

        cardView_RegisterSubjects.setOnClickListener( new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent( getActivity(), RegisterSubjectActivity.class );
                intent.addFlags( Intent.FLAG_ACTIVITY_NO_ANIMATION );
                startActivity( intent );
            }
        } );

        cardView_File.setOnClickListener( new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent( getActivity(), StudentActivity.class );
                intent.addFlags( Intent.FLAG_ACTIVITY_NO_ANIMATION );
                startActivity( intent );
            }
        } );
        cardView_Notification.setOnClickListener( new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                ((BottomNavigationView)getActivity().findViewById(R.id.bottom_navigation)).setSelectedItemId(R.id.action_notification);
            }
        } );
    }

//    public void onChange(){
//        ((BottomNavigationView)getActivity().findViewById(R.id.bottom_navigation)).setSelectedItemId(R.id.action_lesson);
//    }

}
